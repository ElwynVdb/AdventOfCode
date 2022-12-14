import readInputForDay from "../InputUtil";

const input = readInputForDay("10").split("\r\n");

const LENGTHS: { [key: string]: number } = {
    noop: 1,
    addx: 2
}

interface IAction {
    cyclesPassed: number;
    maxCycles: number;
    toAdd: number;
}
const outPut: { [key: number]: number } = {};

const simulateCPU = () => {
    const actions = createActions();

    let cycle = 0;
    let xReg = 1;
    while (actions.length > 0) {
        outPut[cycle + 1] = xReg;
        const action = actions[0];

        action.cyclesPassed++;

        if (action.cyclesPassed == action.maxCycles) {
            xReg += action.toAdd;
            actions.shift();
        }

        cycle++;
    }
}

const createActions = (): IAction[] => {
    return input.map(cmd => {
        const split = cmd.split(" ");

        return {
            cyclesPassed: 0,
            maxCycles: LENGTHS[split[0]],
            toAdd: split[1] ? parseInt(split[1]) : 0
        };
    })
}

simulateCPU();

const partOne = () => [20, 60, 100, 140, 180, 220].map(v => outPut[v] * v).reduce((a, b) => a + b);

const partTwo = () => {

}

console.log(partOne());
console.log(partTwo());