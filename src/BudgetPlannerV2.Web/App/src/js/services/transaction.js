import Promise from "promise";

export const transactionService = {
    getTransactions() {
        return Promise((resolve, reject) => {
            window.setTimeout(() => {
                resolve({
                    lastUpdated: Date(),
                    data: [{
                        id: 1,
                        budgetId: 1,
                        description: "Rent",
                        amount: 1100,
                        type: "Out",
                        created: new Date(2020, 8, 25)
                    },
                    {
                        id: 2,
                        budgetId: 1,
                        description: "Council Tax",
                        amount: 135.99,
                        type: "Out",
                        created: new Date(2020, 8, 25)
                    },
                    {
                        id: 3,
                        budgetId: 1,
                        description: "Utility - Energy",
                        amount: 100,
                        type: "Out",
                        created: new Date(2020, 8, 25)
                    },
                    {
                        id: 4,
                        budgetId: 1,
                        description: "Utility - Home Broadband and Phone",
                        amount: 21.85,
                        type: "Out",
                        created: new Date(2020, 8, 25)
                    }, {
                        id: 5,
                        budgetId: 2,
                        description: "Accomodation",
                        amount: 440.89,
                        type: "Out",
                        created: new Date(2020, 8, 25)
                    },
                    {
                        id: 6,
                        budgetId: 2,
                        description: "Breakfast",
                        amount: 8.99,
                        type: "Out",
                        created: new Date(2020, 8, 25)
                    },
                    {
                        id: 7,
                        budgetId: 2,
                        description: "Dinner",
                        amount: 22.58,
                        type: "Out",
                        created: new Date(2020, 8, 25)
                    },
                    {
                        id: 8,
                        budgetId: 2,
                        description: "Excursions",
                        amount: 21.85,
                        type: "Out",
                        created: new Date(2020, 8, 25)
                    }]
                })
            }, 1000);
        });
    }
}