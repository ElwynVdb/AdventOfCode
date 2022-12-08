import readInputForDay from "../InputUtil";

const input: string[] = readInputForDay("07").split("\r\n");

class CommandPrompt {
    private _fileSystem: IDirectory;
    public get fileSystem() {
        return this._fileSystem;
    }

    constructor(input: string[]) {
        this._fileSystem = this.readFileSystem(input);
    }

    public getDirectorySizes = () => {
        const memo: { [key: string]: number } = {}

        this.getCountForDir(this._fileSystem, memo);

        const memoValues = Object.values(memo);
        return memoValues;
    }

    public getCountForDir = (dir: IDirectory, memo: { [key: string]: number }) => {
        let count = 0;

        if (memo[dir.absolutePath]) return memo[dir.absolutePath];

        if (dir.files) count += dir.files.reduce((b, n) => b + n[1], 0);
        if (dir.childDirs && dir.childDirs.length > 0) dir.childDirs.forEach((dir) => count += this.getCountForDir(dir, memo))

        memo[dir.absolutePath] = count;
        return count
    }

    public smallestDirectoryToFree(size: number) {
        const sizes: number[] = this.getDirectorySizes();
        return sizes.filter(sizeEntry => sizeEntry >= size).sort((a, b) => a - b)[0];
    }

    private readFileSystem = (input: string[]) => {
        const root: IDirectory = {
            path: "/",
            absolutePath: ""
        };

        let currentDirectory = root.path;
        let listingMode = false;

        for (let lineIndex = 0; lineIndex < input.length; lineIndex++) {
            const line = input[lineIndex];

            if (line.startsWith("$")) {
                listingMode = false;
                const cmd = this.getCommandWithArg(line);

                switch (cmd[0]) {
                    case "cd": currentDirectory = this.changeDirectory(root, currentDirectory, cmd[1])!; break;
                    case "ls": listingMode = true; continue;
                }
            }

            if (listingMode) {
                const entrySplit = line.split(" ");
                const currentDir: IDirectory = this.getDirectoryByPath(root, currentDirectory);

                if (entrySplit[0] === "dir") {
                    if (!currentDir.childDirs) currentDir.childDirs = [];
                    currentDir.childDirs!.push({
                        path: entrySplit[1],
                        absolutePath: `${currentDir.absolutePath}/${entrySplit[1]}`,
                        parentDirectory: currentDir.absolutePath
                    });
                    continue;
                }

                if (!currentDir.files) currentDir.files = [];
                currentDir.files.push([entrySplit[1], parseInt(entrySplit[0])]);
            }
        }
        
        return root;
    }

    private getDirectoryByPath = (rootDir: IDirectory, path: string) => {
        if (path === "/" || path === "") return rootDir;

        const split = path.split("/");
        let tempDir = rootDir;

        for (let x = 1; x < split.length; x++) {
            tempDir = tempDir.childDirs?.find(dir => dir.absolutePath === split.filter((s, i) => i <= x).join("/"))!;
        }

        return tempDir;
    }

    private getCommandWithArg = (commandLine: string) => {
        const seperated = commandLine.split(" ");
        return [seperated[1], seperated[2]];
    }

    private changeDirectory = (rootDir: IDirectory, directoryNow: string, to: string) => {
        const currentDir = this.getDirectoryByPath(rootDir, directoryNow);

        if (to === "..") return this.getDirectoryByPath(rootDir, currentDir.parentDirectory!).absolutePath;
        if (to === "/") return rootDir.absolutePath;

        return currentDir.childDirs?.find(dir => dir.absolutePath === directoryNow + "/" + to)?.absolutePath;
    }
}

interface IDirectory {
    path: string;
    absolutePath: string;
    parentDirectory?: string;
    files?: [string, number][] // File Name & Size
    childDirs?: IDirectory[];
}

const partOne = () => {
    const cmd = new CommandPrompt(input);
    return cmd.getDirectorySizes().filter(c => c < 100000).reduce((b, n) => b + n, 0);
}

const partTwo = () => {
    const cmd = new CommandPrompt(input);
    const toFree = 30000000 - (70000000 - cmd.getCountForDir(cmd.fileSystem, {}));
    return cmd.smallestDirectoryToFree(toFree);
}

console.log(partOne());
console.log(partTwo());