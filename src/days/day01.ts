import readInputForDay from "../InputUtil";

const input: string = readInputForDay("01");

const splitInput = input.split("\r\n");
const caloriesCompiled: number[] = [];

let tempColorieCount = 0;
splitInput.forEach(c => {
    if (c === "") {
        caloriesCompiled[caloriesCompiled.length] = tempColorieCount;
        tempColorieCount = 0;
        return;
    }

    tempColorieCount += parseInt(c);
});

const sorted = caloriesCompiled.sort((first, second) => second - first);

const partOne = () => sorted[0];

const partTwo = () => sorted.filter((_s, i) => i <= 2).reduce((base, next) => base + next);

console.log(partOne());
console.log(partTwo());