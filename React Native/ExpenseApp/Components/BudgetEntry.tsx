/* eslint-disable prettier/prettier */
import {Pressable, Text, TextInput} from '@react-native-material/core';
import React, {useState} from 'react';
import {
  ScrollView,
  StatusBar,
  StyleSheet,
  View,
  ActivityIndicator,
} from 'react-native';
import {useDispatch} from 'react-redux';
import {saveData} from '../Redux/action';

function BudgetEntry(prop: {navigation: {navigate: (arg0: string) => void}}) {
  const [name, setName] = useState('');
  const [amount, setAmount] = useState('');
  const [actualAmount, setActualAmount] = useState('');
  const [nameError, setNameError] = useState(false);
  const [amountError, setAmountError] = useState(false);
  const [actualAmountError, setActualAmountError] = useState(false);
  const [show, setShow] = useState(false);
  const dispatch = useDispatch();
  const AddData = () => {
    !name ? setNameError(true) : setNameError(false);
    !amount ? setAmountError(true) : setAmountError(false);
    !actualAmount ? setActualAmountError(true) : setActualAmountError(false);
    if (!name || !actualAmount || !amount) {
      return;
    }
    const item = {
      // id:id,
      name: name,
      amount: amount,
      actualAmount: actualAmount,
    };
    dispatch(saveData(item));
  };

  const restFormData = () => {
    setName('');
    setAmount('');
    setActualAmount('');
  };
  const ActivityLoaders = () => {
    setShow(true);
    setTimeout(() => {
      setShow(false);
    }, 3000);
  };

  return (
    <ScrollView style={budgetStyle.main}>
      <StatusBar backgroundColor="orange" />
      <View style={budgetStyle.boxInput}>
        <TextInput
          label="Name"
          style={budgetStyle.textInput}
          variant="standard"
          onChangeText={text => setName(text)}
          value={name}
        />
        {nameError ? (
          <Text style={budgetStyle.errorText}>Please Enter Valid Nmae</Text>
        ) : null}
        <TextInput
          label="Amount"
          style={budgetStyle.textInput}
          variant="standard"
          onChangeText={num => setAmount(num)}
          value={amount}
        />
        {amountError ? (
          <Text style={budgetStyle.errorText}>Please Enter Valid Amount</Text>
        ) : null}
        <TextInput
          label="Actual Amount"
          style={budgetStyle.textInput}
          variant="standard"
          value={actualAmount}
          onChangeText={text => setActualAmount(text)}
        />
        {actualAmountError ? (
          <Text style={budgetStyle.errorText}>
            Please Enter Valid Actual Amount
          </Text>
        ) : null}
        <ActivityIndicator size="large" color="red" animating={show} />
      </View>
      <View style={budgetStyle.pressableView}>
        <Pressable
          onPressIn={() => AddData()}
          onPress={() => ActivityLoaders()}
          onPressOut={() => restFormData()}>
          <Text style={budgetStyle.pressableBtn}>Save Items</Text>
        </Pressable>
        <Pressable onPress={() => prop.navigation.navigate('BudgetListing')}>
          <Text style={budgetStyle.pressableBtn}>Show Items</Text>
        </Pressable>
      </View>
    </ScrollView>
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
    backgroundColor: 'skyblue',
    marginHorizontal: 20,
    marginTop: 70,
    borderRadius: 20,
  },
  textInput: {
    backgroundColor: 'skyblue',
    marginHorizontal: 10,
    marginVertical: 10,
    borderRadius: 30,
  },
  errorText: {
    color: 'red',
    marginLeft: 20,
  },
});
export default BudgetEntry;
