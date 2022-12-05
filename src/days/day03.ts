import readInputForDay from "../InputUtil";

const input: string[] = readInputForDay("03").split("\r\n");

const getPriority = (letter: string) => {
    const lowerCase = letter.toUpperCase() !== letter;
    const startRange = lowerCase ? 97 : 65;
    const offset = lowerCase ? 1 : 27;
    return (letter.charCodeAt(0) - startRange) + offset;
}

const partOne = () => {
    let counter = 0;

    input.forEach(rContent => {
        const half = rContent.length / 2;
        const compartments = [rContent.substring(0, half), rContent.substring(half, rContent.length)];
        const common = rContent.split("").filter((item) => compartments[0].includes(item) && compartments[1].includes(item));
        counter += getPriority(common[0]);
    });

    return counter;
}

const partTwo = () => {
    let counter = 0;

    for (let x = 0; x < input.length; x += 3) {
        const group = input.filter((content, i) => i >= x &&  i <= (x + 2));   
        const common = group.join("").split("").filter((item) => group[0].includes(item) && group[1].includes(item) && group[2].includes(item));
        counter += getPriority(common[0]);
    }

    return counter;
}

console.log(partOne());
console.log(partTwo());