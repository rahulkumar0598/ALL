/* eslint-disable prettier/prettier */
import React, {useEffect, useState} from 'react';
import {useIsFocused} from '@react-navigation/native';

import {Text, View, StyleSheet, Image} from 'react-native';
import {openDatabase} from 'react-native-sqlite-storage';
import {FlatList} from 'react-native-gesture-handler';
import {getColorByLetter} from '../Assest/colors';

let db = openDatabase({name: 'UserDatabase8.db'});
function FavouriteList() {
  const [userList, setUserList] = useState([]);
  const isFocused = useIsFocused();

  useEffect(() => {
    db.transaction(tnx => {
      tnx.executeSql(
        'SELECT * FROM contact_user order by name',
        [],
        (tx, res) => {
          // console.log(res);
          let temp = [];
          for (let i = 0; i < res.rows.length; ++i) {
            temp.push(res.rows.item(i));
            setUserList(temp);
          }
        },
      );
    });
  }, [isFocused]);
  return (
    <View style={styles.container}>
      <FlatList
        data={userList}
        renderItem={({item, index}) => {
          return (
            <View>
              {item.favourite === '1' ? (
                <View style={styles.userItem}>
                  {item.image ? (
                    <Image source={{uri: item.image}} style={[styles.photo]} />
                  ) : (
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
                  )}
                  <Text style={[styles.textStyle, styles.textStyleName]}>
                    {item.name}
                  </Text>
                </View>
              ) : null}
            </View>
          );
        }}
      />
    </View>
  );
}
const styles = StyleSheet.create({
  container: {
    flex: 1,
    marginTop: 10,
    backgroundColor: 'lightcyan',
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
    marginTop: 10,
    width: '95%',
    // backgroundColor: '#fff',
    backgroundColor: 'cyan',
    marginBottom: 5,
    flex: 1,
    flexDirection: 'row',
    borderRadius: 30,
    marginHorizontal: 10,
  },
  textStyle: {
    color: 'black',
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
  photo: {
    alignContent: 'center',
    marginVertical: 20,
    marginLeft: 30,
    marginRight: 40,
    paddingLeft: 7,
    paddingRight: 7,
    borderRadius: 30,
    width: 50,
    height: 50,
  },
  textStyleName: {
    marginHorizontal: 10,
  },
});
export default FavouriteList;
