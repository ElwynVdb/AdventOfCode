import readInputForDay from "../InputUtil";

const input = readInputForDay("09-test").split("\r\n");

const dirs: { [key: string]: [number, number] } = {
    R: [1, 0],
    L: [-1, 0],
    U: [0, 1],
    D: [0, -1],
};


interface IPosition {
    x: number;
    y: number;
    previous?: [number, number][];
}

const main = () => {
    const grid: number[][] = [];

    let headPosition: IPosition = { x: 0, y: 0, previous: [] };
    let tailPosition: IPosition = { x: 0, y: 0 };

    input.forEach(instruction => {
        const split = instruction.split(" ");
        const dir = dirs[split[0]];

        for (let times = 0; times < parseInt(split[1]); times++) {
            headPosition = { ...headPosition, previous: [[headPosition.x, headPosition.y], ...headPosition.previous!], x: headPosition.x + dir[0], y: headPosition.y + dir[1] }

            if(!areTouching(headPosition, tailPosition) && (headPosition.x != tailPosition.x || headPosition.y != tailPosition.y)) {
                tailPosition = { ...tailPosition, x: headPosition.previous![0][0], y: headPosition.previous![0][1] }
            }

            if (!grid[tailPosition.y]) grid[tailPosition.y] = [];
            if (!grid[tailPosition.y][tailPosition.x]) grid[tailPosition.y][tailPosition.x] = 0;

            grid[tailPosition.y][tailPosition.x] += 1;
        }
    });

    return grid.reduce((b, n) => b + (n.filter(e => e >= 1).length), 0);
}

const areTouching = (head: IPosition, tail: IPosition) => {
    for (let j = -1; j <= 1; j++) {
        for (let k = -1; k <= 1; k++) {
            if (head.x == tail.x + k && head.y == tail.y + j) return true;
        }
    }

    return false;
}

const printGrid = (headPosition: IPosition, tailPosition: IPosition, grid: number[][]) => {
    const copy = JSON.parse(JSON.stringify(grid)); // Deep copy

    for (let y = copy.length - 1; y >= 0; y--) {
        let line = "";
        for (let x = 0; x < copy[y].length; x++) line += copy[y][x] || ".";
        console.log(line);
    }
}


const partOne = () => main();

// const partTwo = () => main();

console.log(partOne());
// console.log(partTwo());