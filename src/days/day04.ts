import readInputForDay from "../InputUtil";

const input: string[] = readInputForDay("04").split("\r\n");

const partOne = () => main(true);

const partTwo = () => main(false);

const main = (all: boolean) => {
    let counter = 0;

    input.forEach(line => {
        const pairs: number[][] = line.split(",").map(ctx => {
            const split = ctx.split("-");
            return [parseInt(split[0]), parseInt(split[1])]
        }).map(partial => {
            const out: number[] = [];
            for (let x = partial[0]; x <= partial[1]; x++) out[out.length] = x;
            return out;
        });

        counter += all ? pairs[0].every((i) => pairs[1].includes(i)) || pairs[1].every((i) => pairs[0].includes(i)) ? 1 : 0
            : pairs[0].some((i) => pairs[1].includes(i)) || pairs[1].some((i) => pairs[0].includes(i)) ? 1 : 0;
    });

    return counter;
}

console.log(partOne());
console.log(partTwo());