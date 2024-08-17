/* eslint-disable prettier/prettier */
import React from 'react';
import {Text, View, StyleSheet,FlatList, Pressable} from 'react-native';
import {useSelector,useDispatch} from 'react-redux';
import { deletData } from '../Redux/action';
import AntDesign from 'react-native-vector-icons/AntDesign';
import MaterialCommunityIcons from 'react-native-vector-icons/MaterialCommunityIcons';


function BudgetListing(prop) {
  const states = useSelector(state => state.reducer);
  console.log(states.budget);
  const data = states.budget;
  const dispatch = useDispatch();
  const deleteItem = (item)=>{
    console.log(item);
    dispatch(deletData(item));
  };
  return (
    <View style={styles.main}>
      <View style={styles.container}>
        <Text style={[styles.headerFontStyle,styles.flex]}>Name</Text>
        <Text style={[styles.headerFontStyle,styles.flex]}>Amount</Text>
        <Text style={[styles.headerFontStyle,styles.flex]}>Actual Amount</Text>
        <Text style={[styles.headerFontStyle,styles.flex]}>Action</Text>
      </View>

      <View>
        {
          data.length ? <FlatList  data={data} renderItem={({item})=>
          <View style={styles.container1}>
            <Text style={[styles.flex1, styles.bodyStyle]}>{item.name}</Text>
            <Text style={[styles.flex, styles.bodyStyle]}>{item.amount}</Text>
            <Text style={[styles.flex, styles.bodyStyle]}>{item.actualAmount}</Text>
            <Pressable style={[styles.bodyStyle,{marginLeft:1}]} onPress={()=>deleteItem(item.name)}><AntDesign name="delete" size={30} color="red" /></Pressable>
            <Pressable style={[styles.bodyStyle]}
            onPress={()=>prop.navigation.navigate('BudgetUpdate',{name:item.name,amount:item.amount,actualAmount:item.actualAmount})}>
            <MaterialCommunityIcons name="update" size={30} color="green" /></Pressable>
          </View>}/> : null
        }
      </View>
    </View>
  );
}
const styles = StyleSheet.create({
  main:{
    flex:1,
    backgroundColor:'skyblue',
  },
  container:{
    flexDirection:'row',
    height:60,
  },
  container1:{
    flex:1,
    flexDirection:'row',
    backgroundColor:'white',
    borderRadius:30,
    marginTop:10,
    shadowColor:'red',
    elevation:8,
    borderColor:'green',
    borderWidth:2,
  },
  flex1: {
    flex:1.3,
  },
  flex: {
    flex: 1,
  },
  headerFontStyle:{
    fontSize:20,
    backgroundColor:'#879CEB',
    paddingTop:15,
    textAlign:'center',
    color:'white',
    fontWeight:'bold',
  },
  bodyStyle:{
    fontSize:19,
    textAlign:'center',
    padding: 15,
  },
});
export default BudgetListing;
