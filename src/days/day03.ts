import { range, sum, xor } from "ramda";
import readInputForDay from "../InputUtil";

const input: string = readInputForDay("03");

const splitInput = input.split("\r\n");

const hasAdjacentSymbol = (grid: string[][], row: number, col: number) => {
    for(let x = -1; x <= 1; x++) {
        for(let y = -1; y <= 1; y++) {
            if((x === 0 && y === 0) || (col+x < 0 || row+y < 0 || row+y >= grid.length || col+x >= grid[row].length)) continue;

            if(grid[row + y][col + x] !== "." && isNaN(parseInt(grid[row + y][col + x]))) {
              return true;
            }
        }
    }

    return false;
}

interface Range {
    lowestPoint: number;
    highestPoint: number;
}

const findNumbers = (row: string[], startIndex: number, lengthString: number): [string, Range] => {
    let numberBuilder = [];

    let lowestPoint = startIndex;
    let highestPoint = startIndex;

    if(row[startIndex] === ".") return ["", {
        lowestPoint: 0,
        highestPoint: 0
    }];
 
    for(let x = startIndex - 1; x >= 0; x--) {
        if(!isNaN(parseInt(row[x]))) {
            lowestPoint = x;
            numberBuilder.unshift(row[x]);
        }else{
            break;
        }
    }

    for(let x = startIndex; x < lengthString; x++) {
        if(!isNaN(parseInt(row[x]))) {
            highestPoint = x;
            numberBuilder.push(row[x]);
        }else{
           break;
        }
    }

    return [numberBuilder.join(""), {lowestPoint, highestPoint}]
}

const partOne = () => {
    const grid = splitInput.map(input => input.split(""));
    let countTotal = 0;

    grid.forEach((row, rowIndex) => {
        for(let columnIndex = 0; columnIndex < row.length; columnIndex++) {
            const [number] = findNumbers(row, columnIndex, row.length);
           
            if(number) {
                columnIndex += number.length;
                if(range(columnIndex - number?.length, columnIndex).some(c => hasAdjacentSymbol(grid, rowIndex, c))) {
                    countTotal+=parseInt(number);
                }
            }
        }
    });

    return countTotal;
}

const partTwo = () => {
    const grid = splitInput.map(input => input.split(""));
    const ratios: number[] = [];

   const gears = grid
   .map((row, rowIndex) => row
   .map((symbol, xIndex) => ({symbol,xIndex,rowIndex}))
   .filter(ob => ob.symbol === "*"))
   .flat();

    gears.forEach((gear) => {
        const hits: string[] = [];
        
        for(let y = 1; y >= -1; y--) {
            const visited: Range[] = [];

            for(let x = 1; x >= -1; x--) {
                if(x === 0 && y === 0) continue;

                const [number, e] = findNumbers(grid[gear.rowIndex + y], gear.xIndex + x, grid[0].length)
             
                if(number && !visited.find(c => (
                    c.highestPoint === e.highestPoint && c.lowestPoint === e.lowestPoint
                ))) {
                    hits.push(number);
                }
                visited.push(e);
            }
        }

        if(hits.length === 2) {
            ratios.push(parseInt(hits[0]) * parseInt(hits[1]));
        }
    })
 
    return sum(ratios);
}

console.log(partOne());
console.log(partTwo());