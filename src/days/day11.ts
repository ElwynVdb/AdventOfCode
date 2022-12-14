import readInputForDay from "../InputUtil";

const input: string[] = readInputForDay("11-test").split("\r\n");

interface Monkey {
    id: number;
    items: bigint[]; // Worry Levels
    operation: (old: bigint) => bigint;
    test: (result: bigint) => boolean;
    truthyReceiver: number;
    falsyReceiver: number;
    inspected: number;
    divisible: bigint;
}

const monkeys: Monkey[] = [];
const numberRegex = /[^\d.]/g;

const deserialize = () => {
    let indexMonkeyLine = 0;
    let currentMonkey: Partial<Monkey> = { inspected: 0 };;

    for (let x = 0; x < input.length; x++) {
        const line = input[x];

        indexMonkeyLine++;

        switch (indexMonkeyLine) {
            case 1:
                currentMonkey.id = parseInt(line.replace(numberRegex, ""));
                break;
            case 2:
                currentMonkey.items = line.replace(numberRegex, " ").split(" ").map(e => parseInt(e)).filter(e => !isNaN(e)).map(BigInt);
                break;
            case 3:
                const actions = line.split(" ").slice(6);

                currentMonkey.operation = (old) => {
                    const lcm = monkeys.map(monkey => monkey.divisible).reduce((a, b) => a * b, BigInt(1));
                    const applyValue = BigInt(actions[1] === "old" ? old.toString() : parseInt(actions[1]).toString());
                    return applyValue % lcm;
                };
                break;
            case 4:
                currentMonkey.divisible = BigInt(line.replace(numberRegex, ""));
                currentMonkey.test = (result) => {
                    return result % currentMonkey.divisible! === BigInt(0)
                };
                break;
            case 5:
                currentMonkey.truthyReceiver = parseInt(line.replace(numberRegex, ""));
                break;
            case 6:
                currentMonkey.falsyReceiver = parseInt(line.replace(numberRegex, ""));
                break;
        }

        if (line === "" || x === input.length - 1) {
            indexMonkeyLine = 0;
            monkeys.push(currentMonkey as Monkey);
            currentMonkey = { inspected: 0 };
            continue;
        }
    }
}

deserialize();

const checkItems = (rounds: number, worried: boolean) => {

    for (let x = 0; x < rounds; x++) {
        monkeys.forEach(monkey => {
            monkey.items.forEach(item => {
                monkey.inspected++;
                const newValue = monkey.operation(item);
                const bored = worried ? Math.floor((parseInt(newValue.toString()) / 3)) : newValue;
                const monkeyToPass = monkey.test(BigInt(bored)) ? monkey.truthyReceiver : monkey.falsyReceiver;
                monkeys[monkeyToPass].items.push(BigInt(bored));
            });

            monkey.items = [];
        });
    }

    return monkeys.map(m => m.inspected).sort((a, b) => b - a).filter((c, i) => i <= 1).reduce((a, b) => a * b);
}


const partOne = () => checkItems(20, true);

const partTwo = () => checkItems(10000, false);


console.log(partOne());
console.log(partTwo());