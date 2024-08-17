/* eslint-disable prettier/prettier */
import {ADD_TO_BUDGET_LIST, DELETE_BUDGET_LIST, UPDATE_BUDGET_LIST} from './constant';

const initialState = {
  budget: [],
};
export const reducer = (
  state = initialState,
  action
) => {
  const newBudget = [...state.budget];
  switch (action.type) {
    case ADD_TO_BUDGET_LIST:
      return {
        ...state,
        budget: [...state.budget, action.data],
      };
     case DELETE_BUDGET_LIST:
      let index = newBudget.findIndex(i=>i.name === action.data);
      let newArray = newBudget.filter((i,idx)=>idx !== index);
      return {
        ...state,
        budget: newArray,
      };
      case UPDATE_BUDGET_LIST:
        const budgetIndex =  newBudget.findIndex(index1=>index1.name === action.data.name);
        newBudget[budgetIndex] = action.data;
        return {
          ...state,
          budget:newBudget,
        };
      default:
      return state;
  }
};
