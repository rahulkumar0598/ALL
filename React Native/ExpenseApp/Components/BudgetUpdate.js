/* eslint-disable prettier/prettier */
import {Pressable, Text, TextInput} from '@react-native-material/core';
import React, { useState} from 'react';
import { StatusBar, StyleSheet, View} from 'react-native';
import {useDispatch} from 'react-redux';
import { updateData} from '../Redux/action';
import {useRoute} from '@react-navigation/native';

function BudgetEntry(prop) {
  const route = useRoute();
  let [name, setName] = useState(route.params.name);
  const [amount, setAmount] = useState(route.params.amount);
  const [actualAmount, setActualAmount] = useState(route.params.actualAmount);
  const [nameError, setNameError] = useState(false);
  const [amountError, setAmountError] = useState(false);
  const [actualAmountError, setActualAmountError] = useState(false);
  const dispatch = useDispatch();
  const UpdateData = () => {
    !name ? setNameError(true) : setNameError(false);
    !amount ? setAmountError(true) : setAmountError(false);
    !actualAmount ? setActualAmountError(true) : setActualAmountError(false);
    if (!name || !actualAmount || !amount) {
      return;
    }
    const item = {
      name: name,
      amount: amount,
      actualAmount: actualAmount,
    };
    dispatch(updateData(item));
  };

  return (
    <View style={budgetStyle.main}>
      <StatusBar backgroundColor="orange" />
      {/* <FlatList data={data} renderItem={({item})=>
      <></>} /> */}
      <View style={budgetStyle.boxInput}>
          <TextInput
            label="Name"
            style={budgetStyle.textInput}
            variant="standard"
            onChangeText={(text) => setName(text)}
            value={name} />
        {nameError ? (
          <Text style={budgetStyle.errorText}>Please Enter Valid Nmae</Text>
        ) : null}
          <TextInput
            label="Amount"
            style={budgetStyle.textInput}
            variant="standard"
            onChangeText={num => setAmount(num)}
            value={amount} />
           {amountError ? (
          <Text style={budgetStyle.errorText}>Please Enter Valid Amount</Text>
        ) : null}
          <TextInput
            label="Actual Amount"
            style={budgetStyle.textInput}
            variant="standard"
            value={actualAmount}
            onChangeText={text => setActualAmount(text)} />
          {actualAmountError ? (
          <Text style={budgetStyle.errorText}>
            Please Enter Valid Actual Amount
          </Text>
        ) : null}
        </View><View style={budgetStyle.pressableView}>
            <Pressable
              onPress={() => UpdateData()}
              onPressOut={() => prop.navigation.navigate('BudgetListing')}>
              <Text style={budgetStyle.pressableBtn}>Save Items</Text>
            </Pressable>
          </View>
    </View>
  );
}

const budgetStyle = StyleSheet.create({
  main: {
    flex: 1,
    backgroundColor: 'skyblue',
  },
  pressableView: {
    // flex: 1,
    justifyContent: 'center',
    // alignItems: 'center',
  },
  pressableBtn: {
    backgroundColor: 'orange',
    color: 'white',
    padding: 10,
    fontSize: 20,
    borderRadius: 30,
    textAlign: 'center',
    shadowColor: 'black',
    elevation: 8,
    margin: 10,
  },
  boxInput: {
    marginHorizontal: 20,
    marginTop: 70,
    borderRadius: 2,
  },
  textInput: {
    marginHorizontal: 10,
    marginVertical: 10,
    borderRadius: 30,
  },
});
export default BudgetEntry;
