import readInputForDay from "../InputUtil";

const input = readInputForDay("09").split("\r\n");

interface IPosition {
    x: number;
    y: number;
}

const main = (tailLength: number) => {
    const grid: number[][] = [];

    const knots: IPosition[] = [];

    for (let i = 0; i < tailLength; i++) knots[i] = { x: 0, y: 0 };

    let headPosition: IPosition = knots[0];

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

            moveTails(knots, visited);

            const tail = knots[knots.length - 1];
            if (!visited.find(c => c.x === tail.x && c.y === tail.y)) {
                visited.push({ x: tail.x, y: tail.y });
            }
        };

    });

    return visited.length;
}

const moveTails = (knots: IPosition[], visited: IPosition[]) => {
    for (let k = 1; k < knots.length; k++) {
        const previousPosition = knots[k - 1];
        const currentPosition = knots[k];

        // Move tail if neccesary
        const headDistanceX = previousPosition.x - currentPosition.x;
        const headDistanceY = previousPosition.y - currentPosition.y;

        const notTouching = Math.abs(headDistanceX) > 1 || Math.abs(headDistanceY) > 1

        if (notTouching) {
            const yMove = Math.sign(headDistanceY);
            const xMove = Math.sign(headDistanceX);

            currentPosition.x += xMove
            currentPosition.y += yMove;
        }
    }
}

const partOne = () => main(2);

const partTwo = () => main(10);

console.log(partOne());
console.log(partTwo());