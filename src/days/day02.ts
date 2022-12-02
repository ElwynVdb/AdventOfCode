import readInputForDay from "../InputUtil";

const input = readInputForDay("02").split("\r\n");

const map: { [key: string]: number } = {
    "X": 1,
    "Y": 2,
    "Z": 3
};

const translationMap: { [key: string]: string } = {
    "A": "X",
    "B": "Y",
    "C": "Z"
}

const partOne = () => {
    let score = 0;

    input.forEach(entry => {
        const choices = entry.split(" ");
        const opponent = translationMap[choices[0]];
        const us = choices[1];

        score += scoreCount(opponent, us);
    });

    return score;
}



const partTwo = () => {
    let score = 0;

    input.forEach(entry => {
        const choices = entry.split(" ");
        const opponent = translationMap[choices[0]];
        let us = "";

        switch (choices[1]) {
            case "X":
                us = ["X", "Y", "Z"].filter(x => !isWinner(opponent, x) && x !== opponent)[0];
                break;
            case "Y":
                us = opponent;
                break;
            case "Z":
                us = opponent === "Z" ? "X" : opponent === "Y" ? "Z" : "Y";
                break;
        }

        score += scoreCount(opponent, us);
    });

    return score;
}

const isWinner = (opponent: string, us: string) => (us == "X" && opponent == "Z") || (us == "Y" && opponent == "X") || (us == "Z" && opponent == "Y");

const scoreCount = (opponent: string, us: string) => {
    let score = 0;
  
    if (opponent === us) {
        score += 3;
    } else if (isWinner(opponent, us)) {
        score += 6;
    }

    score += map[us];

    return score;
}

console.log(partOne());
console.log(partTwo());