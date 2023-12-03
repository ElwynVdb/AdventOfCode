import { range, sum } from "ramda";
import readInputForDay from "../InputUtil";

const input: string = readInputForDay("01");

const splitInput = input.split("\r\n");

const partOne = () => {
    return sum(
        splitInput.map((input) => (
            input.split("")
            .filter(symbol => !isNaN(parseInt(symbol)))
            .join("")
        )).map(numbers => {
            const combinedNumber =  parseInt(numbers[0] + numbers[numbers.length - 1]);
            return isNaN(combinedNumber) ? 0 : combinedNumber;
        })
    );
}

const mapping: any = {
    "one": 1,
    "two": 2,
    "three": 3,
    "four": 4,
    "five":  5,
    "six": 6,
    "seven": 7,
    "eight": 8,
    "nine": 9
};

const partTwo = () => {
    
   const c =  splitInput.map(input => {
        const foundNumbers: number[] = [];

        range(0, input.length).forEach(index => {
            if(!isNaN(parseInt(input[index]))) {
                foundNumbers.push(parseInt(input[index]));
            }
    
            Object.entries(mapping).forEach(([mapKey, mapValue]) => {
                const found = mapping[input.substring(index, index + mapKey.length)];
           
                if(found) {
                    foundNumbers.push(found);
                }
            })
        }) 


        return foundNumbers[0] + "" + foundNumbers[foundNumbers.length - 1];
    });

    return sum(c.map(number => parseInt(number)));
}

console.log(partOne());
console.log(partTwo());