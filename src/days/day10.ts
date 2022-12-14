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

const cpuOutput: { [key: number]: number } = {};

const simulateCPU = () => {
    const actions = createActions();

    let cycle = 0;
    let xReg = 1;
    while (actions.length > 0) {
        cpuOutput[cycle + 1] = xReg;
        const action = actions[0];

        action.cyclesPassed++;

        if (action.cyclesPassed == action.maxCycles) {
            xReg += action.toAdd;
            actions.shift();
        }

        cycle++;
    }
}

const CRTOutput: string[] = [];

const simulateCRT = () => {
    let index = 0;
    let row = 0;

    Object.entries(cpuOutput).forEach((pair, i) => {

        if (i % 40 == 0 && i != 0) {
            row++;
            index = 0;
        }

        index++;

        if (!CRTOutput[row] && CRTOutput[row] !== "") CRTOutput[row] = "";

        const valueForCycle = pair[1];
        CRTOutput[row] += indexesAfterShift(valueForCycle).includes(index) ? "#" : ".";
    });
}

const indexesAfterShift = (shift: number) => [shift, shift + 1, shift + 2];


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
simulateCRT();

const partOne = () => [20, 60, 100, 140, 180, 220].map(v => cpuOutput[v] * v).reduce((a, b) => a + b);

const partTwo = () => CRTOutput.join("\n");

console.log(partOne());
console.log(partTwo());