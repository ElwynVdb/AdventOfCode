import readInputForDay from "../InputUtil";

const input: string[] = readInputForDay("11-test").split("\r\n");

interface Monkey {
    id: number;
    items: number[]; // Worry Levels
    operation: (old: number) => number;
    test: (result: number) => boolean;
    truthyReceiver: number;
    falsyReceiver: number;
}

const monkeys: Monkey[] = [];
const numberRegex = /[^\d.]/g;

const deserialize = () => {

    let indexMonkeyLine = 0;
    let currentMonkey: Partial<Monkey> = {};

    for (let x = 0; x < input.length; x++) {
        const line = input[x];

        if (line === "") {
            indexMonkeyLine = 0;
            monkeys.push(currentMonkey as Monkey);
            currentMonkey = {};
            continue;
        }

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
                currentMonkey.test = (result) => result % parseInt(line.replace(numberRegex, "")) === 0;
                break;
            case 5:
                currentMonkey.truthyReceiver = parseInt(line.replace(numberRegex, ""));
                break;
            case 6:
                currentMonkey.falsyReceiver = parseInt(line.replace(numberRegex, ""));
                break;
        }
    }
}

deserialize();

const partOne = () => {

}

const partTwo = () => {

}


console.log(partOne());
console.log(partTwo());