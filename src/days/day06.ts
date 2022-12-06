import readInputForDay from "../InputUtil";

const input: string[] = readInputForDay("06").split("");

const main = (size: number) => {
    let temp = "";

    for (let x = 0; x < input.length; x++) {
        for (let y = 0; y <= (size - 1); y++)
            temp += input[x + y] || "";


        const set = [...new Set(temp.split(""))];

        if (set.length === size)
            return x + size;

        temp = "";
    }

    return -1;
}

const partOne = () => main(4);

const partTwo = () => main(14)

console.log(partOne());
console.log(partTwo());