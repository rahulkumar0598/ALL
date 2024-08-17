/* eslint-disable prettier/prettier */
import {useIsFocused, useNavigation} from '@react-navigation/native';
import React, {useEffect, useState} from 'react';
import {Pressable, StyleSheet, Text, View, Alert} from 'react-native';
import {FlatList, TextInput} from 'react-native-gesture-handler';
import {openDatabase} from 'react-native-sqlite-storage';
import ContactItem from './ContactItem';
// import Animated from 'react-native-reanimated';
let db = openDatabase({name: 'UserDatabase8.db'});

function Contact() {
  const navigation = useNavigation();
  const [userList, setUserList] = useState([]);
  const isFocused = useIsFocused();
  const [masterData, setMasterData] = useState([]);
  const [searches, setSearches] = useState('');
  const fetchingData = () => {
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
  };
  useEffect(() => {
    fetchingData();
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
  const deleteItem = id => {
    console.log(id);
    db.transaction(tnx => {
      tnx.executeSql(
        'DELETE from contact_user where contact_id=?',
        [id],
        (tx, res) => {
          console.log('Results', res.rowsAffected);
          if (res.rowsAffected > 0) {
            Alert.alert(
              'Success',
              'User deleted successfully',
              [
                {
                  text: 'Ok',
                  onPress: () => {
                    fetchingData();
                  },
                },
              ],
              {cancelable: false},
            );
          } else {
            Alert.alert('Please insert a valid User Id');
          }
        },
      );
    });
  };
  return (
    <View style={styles.container}>
      <TextInput
        placeholder="Search"
        onChangeText={text => SeachUser(text.toUpperCase())}
        value={searches}
        style={styles.serachBoxStyle}
      />
      <FlatList
        data={userList}
        renderItem={({item, index}) => {
          return (
            <ContactItem
              data={item}
              deleteContact={() => deleteItem(item.contact_id)}
            />
          );
        }}
      />
      <Pressable
        style={styles.addNewBtn}
        onPress={() => navigation.navigate('CreateContact')}>
        <Text style={styles.addNewBtnText}>+</Text>
      </Pressable>
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
  addNewBtnText: {
    fontSize: 50,
    fontWeight: 'bold',
    color: 'white',
  },
  serachBoxStyle: {
    left: 300,
    fontSize: 20,
    borderRadius: 5,
    borderColor: 'black',
  },
});
export default Contact;
