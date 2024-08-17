/* eslint-disable prettier/prettier */
import {useIsFocused, useNavigation} from '@react-navigation/native';
import React, {useEffect, useState} from 'react';
import {Pressable, StyleSheet, Text, View} from 'react-native';
import {FlatList, TextInput} from 'react-native-gesture-handler';
import {openDatabase} from 'react-native-sqlite-storage';
import {getColorByLetter} from '../Assest/colors';

let db = openDatabase({name: 'UserDatabase8.db'});

const Search = () => {
  const navigation = useNavigation();
  const [userList, setUserList] = useState([]);
  const [masterData, setMasterData] = useState([]);
  const isFocused = useIsFocused();
  const [searches, setSearches] = useState('');
  useEffect(() => {
    db.transaction(txn => {
      txn.executeSql(
        'SELECT * FROM contact_user order by name ASC',
        [],
        (tx, res) => {
          // console.log(res.rows.item);
          let temp = [];
          for (let i = 0; i < res.rows.length; ++i) {
            console.log(res.rows.item(i));
            temp.push(res.rows.item(i));
            setUserList(temp);
            setMasterData(temp);
          }
        },
      );
    });
  }, [isFocused]);
  const SeachUser = text => {
    if (text) {
      const newData = masterData.filter(item => {
        const itemData = item.name ? item.name.toUpperCase() : ''.toUpperCase();
        const textData = text.toUpperCase();
        return itemData.indexOf(textData) > -1;
      });
      setUserList(newData);
      setSearches(text);
    } else {
      setUserList(masterData);
      setSearches(text);
    }
  };
  return (
    <View>
      <TextInput
        placeholder="Search"
        onChangeText={text => SeachUser(text.toUpperCase())}
        value={searches}
      />
      <FlatList
        data={userList}
        keyExtractor={(item, index) => index.toString()}
        renderItem={({item, index}) => {
          return (
            <Pressable
              onPress={() =>
                navigation.navigate('UpdateContact', {
                  data: {
                    name: item.name,
                    mobile: item.mobile,
                    landline: item.landline,
                    favourite: item.favourite,
                    colour: item.colour,
                    image: item.image,
                    id: item.contact_id,
                  },
                })
              }
              onLongPress={() => console.log('delete User')}
              style={styles.userItem}>
              <Text
                style={[
                  styles.textStyle,
                  styles.textStyleImage,
                  {
                    backgroundColor: getColorByLetter(item.name[0]),
                  },
                ]}>
                {item.name[0]}
              </Text>
              <Text style={[styles.textStyle, styles.textStyleName]}>
                {item.name.toUpperCase()}
              </Text>
            </Pressable>
          );
        }}
      />
    </View>
  );
};
const styles = StyleSheet.create({
  container: {
    flex: 1,
    marginTop: 10,
  },
  addNewBtn: {
    backgroundColor: 'purple',
    width: 75,
    height: 75,
    position: 'absolute',
    bottom: 20,
    right: 20,
    justifyContent: 'center',
    alignItems: 'center',
    borderRadius: 40,
  },
  userItem: {
    width: '100%',
    // backgroundColor: '#fff',
    // backgroundColor: 'grey',
    marginBottom: 5,
    flex: 1,
    flexDirection: 'row',
    borderRadius: 30,
    marginLeft: 10,
  },
  textStyle: {
    // color: 'white',
    fontSize: 20,
    marginVertical: 20,
  },
  textStyleImage: {
    marginLeft: 30,
    marginRight: 40,
    alignItems: 'center',
    justifyContent: 'center',
    paddingLeft: 7,
    paddingRight: 7,
    borderRadius: 20,
    fontSize: 20,
    // aspectRatio: 1,
  },
  textStyleName: {
    marginHorizontal: 10,
  },
});
export default Search;
