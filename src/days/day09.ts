import readInputForDay from "../InputUtil";

const input = readInputForDay("09-test").split("\r\n");

const dirs: { [key: string]: [number, number] } = {
    R: [1, 0],
    L: [-1, 0],
    U: [0, -1],
    D: [0, 1],
};


// interface IPosition {
//     x: number;
//     y: number;
//     xO: number;
//     yO: number;
// }

const main = (knots: number) => {
    
}

const partOne = () => main(2);

const partTwo = () => {

}

console.log(partOne());
console.log(partTwo());