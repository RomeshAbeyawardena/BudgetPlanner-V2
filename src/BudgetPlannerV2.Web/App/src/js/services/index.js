import { budgetService } from "./budget";
import { transactionService } from "./transaction";
import { userService } from "./user";


const services = {
    budgetService: budgetService,
    transactionService: transactionService,
    userService: userService
}

export default services;