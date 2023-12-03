import readInputForDay from "../InputUtil";

const input: string = readInputForDay("02");

const splitInput = input.split("\r\n");

class Game {

    public gameId: number;

    public redSize: number = 0;
    public blueSize: number = 0;
    public greenSize: number = 0;

    constructor(gameInput: string) {
        const colonIndex = gameInput.indexOf(":");
        this.gameId = parseInt(gameInput.substring(0, colonIndex).replace("Game ", ""));
        const subSets = gameInput.substring(colonIndex + 1).replace(/ /g, "$");

        subSets.split(";").forEach(sub => {
            sub.split(",").forEach(subInner => {
                const [_, amount, color] = subInner.split("$");
                const amountParsed = parseInt(amount);

                switch(color) {
                    case "green": 
                        this.greenSize = amountParsed > this.greenSize ? amountParsed : this.greenSize;;
                        break;
                    case "red": 
                        this.redSize = amountParsed > this.redSize ? amountParsed : this.redSize;;
                        break;
                    case "blue":
                        this.blueSize = amountParsed > this.blueSize ? amountParsed : this.blueSize;;
                        break;
                }
            })
        });
    }

    isPossible() {
        return this.redSize <= 12 && this.blueSize <= 14 && this.greenSize <= 13;
    }

    power() {
        return this.redSize * this.blueSize * this.greenSize;
    }
}

const partOne = () => {
    let possibleCount = 0;

    splitInput.forEach(input => {
        const game = new Game(input);

        if(game.isPossible()) {
            possibleCount += game.gameId;
        }
    });

    return possibleCount;
}

const partTwo = () => {
    let powerCount = 0;

    splitInput.forEach(input => {
        const game = new Game(input);

        powerCount += game.power();
    });

    return powerCount;
}

console.log(partOne());
console.log(partTwo());