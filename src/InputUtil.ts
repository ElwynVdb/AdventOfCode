import fs from "fs";

const readInputForDay = (day: string): string => fs.readFileSync(`${__dirname}/inputs/${day}.txt`, { encoding: "utf-8" });

export default readInputForDay;