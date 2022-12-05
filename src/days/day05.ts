import readInputForDay from "../InputUtil";

const input: string[] = readInputForDay("05").split("\r\n");

class Ship {
    private _craneInstructions: Instruction[] = [];
    private _stacks: Stack[] = [];

    constructor(input: string[]) {
        this.setup(input);
        //  console.log(this._stacks.length);
    }

    private setup = (input: string[]) => {
        const filledMissing = input.map(line => line.replace(/ {4}/g, " [$] ").replace(/ {2}/g, " ").trim());

        let compilingLayout = true;
        const stacks: string[][] = [];

        for (let x = 0; x < input.length; x++) {
            const line = filledMissing[x];

            if (compilingLayout && !line.includes("[")) {
                compilingLayout = false;
                stacks.forEach(containers => this._stacks.push(new Stack(containers)));
                continue;
            }

            if (line == "") continue;

            // Layout
            if (compilingLayout) {
                const rawEntry = line.split(" ").map(c => c.replace("[", "").replace("]", ""));

                rawEntry.forEach((e, i) => {
                    if (e !== "$") {
                        if (!stacks[i]) stacks[i] = [];
                        stacks[i].push(e);
                    }
                });

                continue;
            }

            // Instructions
            const instructionNumbers = line.split(" ").map((c) => parseInt(c)).filter(e => !isNaN(e));
            const instruction = new Instruction(instructionNumbers[1], instructionNumbers[2], instructionNumbers[0]);
            this._craneInstructions.push(instruction);
        }
    }

    public applyInstructions = () => {
        this._craneInstructions.forEach(instruction => {
            const removed = this._stacks[instruction.from - 1].remove(instruction.count);
            this._stacks[instruction.to - 1].add(removed);
        });

        return this;
    }

    public get getTopWord() {
        return this._stacks.reduce((base, next) => base + next.getTopContainer, "")
    }
}

class Stack {
    private _containers: string[];

    constructor(containers: string[]) {
        this._containers = containers;
    }

    public remove = (amount: number) => {
        const removal = this._containers.filter((v, i) => i < amount);
        this._containers = this._containers.filter((v, i) => i >= amount);
        return removal;
    }

    public add = (containers: string[]) => {
        for (let x = 0; x < containers.length; x++) {
            this._containers.unshift(containers[x]);
        }
    };

    public get getTopContainer() {
        return this._containers.at(0);
    }

    public get containers() {
        return this._containers;
    }
}

class Instruction {
    private _from: number;
    private _to: number;
    private _count: number;

    constructor(fromStack: number, toStack: number, amount: number) {
        this._from = fromStack;
        this._to = toStack;
        this._count = amount;
    }

    public get from() {
        return this._from;
    }

    public get to() {
        return this._to;
    }

    public get count() {
        return this._count;
    }
}

const ship = new Ship(input).applyInstructions();

console.log(ship.getTopWord);