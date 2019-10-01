module.exports = {
    preset: 'ts-jest',
    testEnvironment: 'node',
    roots: [
        "./wwwroot/src"
    ],
    // "moduleFileExtensions": [
    //     "ts",
    //     "tsx",
    //     "js",
    //     "jsx",
    //     "json"
    // ],
    testRegex: "(/__tests__/.*|(\\.|/)(test|spec))\\.tsx?$",
    // "transform": {
    //     "^.+\\.tsx?$": "ts-jest"
    // },
    snapshotSerializers: ["enzyme-to-json/serializer"],
    setupTestFrameworkScriptFile: "./wwwroot/src/__tests__/setup/setupEnzyme.ts",
    testPathIgnorePatterns: ["./wwwroot/src/__tests__/setup/"]
};

