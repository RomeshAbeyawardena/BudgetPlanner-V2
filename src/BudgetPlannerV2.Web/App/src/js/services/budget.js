import Promise from "promise";

export const budgetService = {
    getBudgets() {
        return new Promise((resolve, reject) => {
            window.setTimeout(() => {
                resolve({
                    lastUpdated: Date(),
                    data: [{
                        id: 1,
                        name: "Monthly Budget",
                        description: "Monthly budget check",
                        balance: 188.88,
                        availableToSpend: 96.99,
                        created: new Date(2020, 8, 25),
                        modified: new Date(2020, 8, 26)
                    }, {
                        id: 2,
                        name: "Holiday Budget",
                        description: "Holiday budget check",
                        balance: 350.00,
                        availableToSpend: 350.00,
                        created: new Date(2020, 8, 25),
                        modified: new Date(2020, 8, 25)
                    }]
                })
            }, 1000);
        });
    }
}