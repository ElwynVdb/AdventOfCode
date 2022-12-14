import readInputForDay from "../InputUtil";

const input = readInputForDay("09").split("\r\n");

interface IPosition {
    x: number;
    y: number;
}

const main = () => {
    const grid: number[][] = [];

    let headPosition: IPosition = { x: 0, y: 0 };
    let tailPosition: IPosition = { x: 0, y: 0 };

    const visited: IPosition[] = [];

    input.forEach(instruction => {
        const split = instruction.split(" ");
        const dir = split[0]; // Direction in a tuple [X, Y]
        const times = parseInt(split[1]);


        for (let ci = 0; ci < times; ci++) {
            // Move Head by given direction
            switch (dir) {
                case "L": headPosition.x -= 1; break;
                case "R": headPosition.x += 1; break;
                case "U": headPosition.y -= 1; break;
                case "D": headPosition.y += 1; break;
            }

            // Move tail if neccesary
            const headDistanceX = headPosition.x - tailPosition.x;
            const headDistanceY = headPosition.y - tailPosition.y;

            const notTouching = Math.abs(headDistanceX) > 1 || Math.abs(headDistanceY) > 1

            if (notTouching) {
                const yMove = Math.sign(headDistanceY);
                const xMove = Math.sign(headDistanceX);

                tailPosition.x += xMove
                tailPosition.y += yMove;
            }

            if(!visited.find(c => c.x === tailPosition.x && c.y === tailPosition.y)) {
                visited.push({x: tailPosition.x, y: tailPosition.y});
            }
         
        };
    });

    return visited.length;
}


const printGrid = (headPosition: IPosition, tailPosition: IPosition, grid: string[][]) => {
    const copy = JSON.parse(JSON.stringify(grid)); // Deep copy

    copy[0][0] = "s";
    copy[headPosition.y][headPosition.x] = "H";
    copy[tailPosition.y][tailPosition.x] = "T";

    for (let y = copy.length - 1; y >= 0; y--) {
        let line = "";
        for (let x = 0; x < copy[y].length; x++) line += copy[y][x] ? copy[y][x] : ".";
        console.log(line);
    }
}


const partOne = () => main();

// const partTwo = () => main();

console.log(partOne());
// console.log(partTwo());