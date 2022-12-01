import fs from "fs";

const readInputForDay = (day: string): string => fs.readFileSync(`../inputs/${day}.txt`, { encoding: "utf-8" });

export default readInputForDay;