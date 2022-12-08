import readInputForDay from "../InputUtil";

const input: number[][] = readInputForDay("08").split("\r\n").map(row => row.split("").map(n => parseInt(n)));

const partOne = () => {
    let count = 0;

    for (let y = 0; y < input.length; y++) {
        for (let x = 0; x < input[y].length; x++) {
            count += isTreeVisibleFromEdge(x, y) ? 1 : 0;
        }
    }

    return count;
}

const partTwo = () => {
    const scores: number[] = [];

    for (let y = 0; y < input.length; y++) {
        for (let x = 0; x < input[y].length; x++) {
            scores.push(getViewDistanceForTree(x, y).reduce((b, n) => {
                return b * n;
            }));
        }
    }

    return scores.sort((a, b) => b - a)[0];
}

const isTreeVisibleFromEdge = (xIndex: number, yIndex: number): boolean => {
    if (yIndex === 0 || (yIndex === input.length - 1) || xIndex === 0 || xIndex === input[0].length - 1) return true;

    let failedSides = 0;
    const treeSize = input[yIndex][xIndex];

    for (let i = yIndex + 1; i < input.length; i++) {
        const otherTreeSize = input[i][xIndex];
        if (otherTreeSize >= treeSize) {
            failedSides++;
            break;
        }
    }

    for (let i = yIndex - 1; i >= 0; i--) {
        const otherTreeSize = input[i][xIndex];
        if (otherTreeSize >= treeSize) {
            failedSides++;
            break;
        }
    }

    for (let k = xIndex + 1; k < input[yIndex].length; k++) {
        const otherTreeSize = input[yIndex][k];
        if (otherTreeSize >= treeSize) {
            failedSides++;
            break;
        }
    }

    for (let k = xIndex - 1; k >= 0; k--) {
        const otherTreeSize = input[yIndex][k];
        if (otherTreeSize >= treeSize) {
            failedSides++;
            break;
        }
    }

    return failedSides < 4;
}

const getViewDistanceForTree = (xIndex: number, yIndex: number): number[] => {
    const treeSize = input[yIndex][xIndex];
    const out: number[] = [0, 0, 0, 0];

    for (let i = yIndex - 1; i >= 0; i--) {
        const otherTreeSize = getSizeForTree(xIndex, i);
        out[0] += 1;
        if (otherTreeSize >= treeSize) break;
    }


    for (let i = yIndex + 1; i < input.length; i++) {
        const otherTreeSize = getSizeForTree(xIndex, i);
        out[1] += 1
        if (otherTreeSize >= treeSize) break;
    }

    for (let k = xIndex - 1; k >= 0; k--) {
        const otherTreeSize = getSizeForTree(k, yIndex);
        out[2] += 1;
        if (otherTreeSize >= treeSize) break;
    }

    for (let k = xIndex + 1; k < input[0].length; k++) {
        const otherTreeSize = getSizeForTree(k, yIndex);
        out[3] += 1;
        if (otherTreeSize >= treeSize) break;
    }

    return out;
}

const getSizeForTree = (xIndex: number, yIndex: number) => input[yIndex][xIndex];

const sizeOfTree = (xIndex: number, yIndex: number): number => input[yIndex][xIndex];

console.log(partOne());
console.log(partTwo());