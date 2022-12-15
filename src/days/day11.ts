import readInputForDay from "../InputUtil";

const input: string[] = readInputForDay("11").split("\r\n");

interface Monkey {
    id: number;
    items: number[]; // Worry Levels
    operation: (old: number) => number;
    test: (result: number) => boolean;
    truthyReceiver: number;
    falsyReceiver: number;
    inspected: number;
    divisible: number;
}

let monkeys: Monkey[] = [];
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
                currentMonkey.items = line.replace(numberRegex, " ").split(" ").map(e => parseInt(e)).filter(e => !isNaN(e));
                break;
            case 3:
                const actions = line.split(" ").slice(6);

                currentMonkey.operation = (old) => {
                    const applyValue = actions[1] === "old" ? old : parseInt(actions[1]);

                    switch (actions[0]) {
                        case "*": return old * applyValue;
                        case "/": return old / applyValue;
                        case "+": return old + applyValue;
                        case "-": return old - applyValue;
                    }

                    return -1;
                };
                break;
            case 4:
                currentMonkey.divisible = parseInt(line.replace(numberRegex, ""));
                currentMonkey.test = (result) => result % parseInt(line.replace(numberRegex, "")) === 0;
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



const checkItems = (rounds: number, worried: boolean) => {

    monkeys = monkeys.filter(m => false);
    deserialize();

    const productOfDivisors = monkeys.map(m => m.divisible).reduce((acc, cur) => acc * cur, 1)


    for (let x = 0; x < rounds; x++) {
        monkeys.forEach(monkey => {
            monkey.items.forEach(item => {
                monkey.inspected++;
                const newValue = monkey.operation(item);
                const bored = Math.floor(worried ? newValue / 3 : (newValue % productOfDivisors));
                const monkeyToPass = monkey.test(bored) ? monkey.truthyReceiver : monkey.falsyReceiver;
                monkeys[monkeyToPass].items.push(bored);
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