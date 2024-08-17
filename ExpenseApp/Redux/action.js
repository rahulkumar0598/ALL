/* eslint-disable prettier/prettier */
import {ADD_TO_BUDGET_LIST,DELETE_BUDGET_LIST, UPDATE_BUDGET_LIST } from './constant';

export function saveData(item) {
  return {
    type: ADD_TO_BUDGET_LIST,
    data: item,
  };
}
export function deletData(item) {
  return {
    type: DELETE_BUDGET_LIST,
    data: item,
  };
}
export function updateData(item){
  return {
    type: UPDATE_BUDGET_LIST,
    data: item,
  };
}

