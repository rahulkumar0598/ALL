/* eslint-disable prettier/prettier */
import React, {useState} from 'react';
import {Pressable, Text, TextInput} from '@react-native-material/core';
import {
  Alert,
  StyleSheet,
  View,
  ImageBackground,
  Image,
  Modal,
} from 'react-native';
import FontAwesome from 'react-native-vector-icons/FontAwesome';
import Ionicons from 'react-native-vector-icons/Ionicons';
import Entypo from 'react-native-vector-icons/Entypo';
import {useNavigation, useRoute} from '@react-navigation/native';
import {openDatabase} from 'react-native-sqlite-storage';
import {launchCamera, launchImageLibrary} from 'react-native-image-picker';

let db = openDatabase({name: 'UserDatabase8.db'});
function UpdateContact() {
  const route = useRoute();

  const [name, setName] = useState(route.params.data.name);
  const [mobile, setMobile] = useState(route.params.data.mobile);
  const [landline, setLandline] = useState(route.params.data.landline);
  const navigation = useNavigation();
  let [favourite, setFavourite] = useState(route.params.data.favourite);
  let [colour, setColor] = useState(route.params.data.colour);
  const [imageUri, setImageUri] = useState(route.params.data.image);
  const [showModal, setSowModal] = useState(false);
  const [nameError, setNameError] = useState(false);
  const [mobileError, setMobileError] = useState(false);
  const [landlineError, setLandlineError] = useState(false);
  console.log(colour);
  const UpdateUser = () => {
    !name ? setNameError(true) : setNameError(false);
    !mobile ? setMobileError(true) : setMobileError(false);
    !landline ? setLandlineError(true) : setLandlineError(false);
    if (!name || !mobile || !landline) {
      return;
    }
    console.log(route.params.data.id);
    db.transaction(tnx => {
      tnx.executeSql(
        'UPDATE contact_user set name=? ,mobile=? ,landline=?,favourite=?, colour=?,image=? where contact_id=?',
        [
          name,
          mobile,
          landline,
          favourite,
          colour,
          imageUri,
          route.params.data.id,
        ],
        (tx, res) => {
          console.log(res);
          if (res.rowsAffected === 1) {
            Alert.alert(
              'Success',
              'Contact Updated Succesfully',
              [
                {
                  text: 'Ok',
                  onPress: () => navigation.navigate('ContactList'),
                },
              ],
              {cancelable: false},
            );
          } else {
            Alert.alert('Update Failed');
          }
        },
      );
    });
  };
  useState(() => {
    setColor(route.params.data.colour);
  }, []);
  // const FavOp = () => {
  //   if (favourite === 0) {
  //     favourite = 1;
  //   } else {
  //     favourite = 0;
  //   }
  //   console.log(favourite);
  // };
  const OpenGallery = () => {
    // const options = {
    //   storageOptions: {
    //     path: 'images',
    //     mediaType: 'photo',
    //     cropping: true,
    //   },
    //   includeBase64: true,
    // };
    const options = {
      title: 'Select Image',
      type: 'library',
      options: {
        selectionLimit: 1,
        mediaType: 'photo',
        includeBase64: true,
        width: 150,
        height: 150,
      },
    };
    launchImageLibrary(options, response => {
      console.log('Response = ', response.assets[0]);
      const fromData = new FormData();
      fromData.append('file', {
        uri: response.assets[0].uri,
        type: response.assets[0].type,
        name: response.assets[0].name,
      });
      console.log(fromData);
      if (response.didCancel) {
        console.log('User Cancelled image picker');
      } else if (response.error) {
        console.log('Image Picker Error :', response.error);
      } else if (response.customButtom) {
        console.log('User tapped Custom Button: ', response.customButtom);
      } else {
        setImageUri(response.assets[0].uri);
        setSowModal(false);
      }
    });
  };
  const OpenCamera = () => {
    const options = {
      title: 'Select Image',
      type: 'library',
      options: {
        selectionLimit: 1,
        mediaType: 'photo',
        includeBase64: true,
        width: 150,
        height: 150,
      },
    };
    launchCamera(options, response => {
      console.log('Response = ', response.assets[0]);
      const fromData = new FormData();
      fromData.append('file', {
        uri: response.assets[0].uri,
        type: response.assets[0].type,
        name: response.assets[0].name,
      });
      console.log(fromData);
      if (response.didCancel) {
        console.log('User Cancelled image picker');
      } else if (response.error) {
        console.log('Image Picker Error :', response.error);
      } else if (response.customButtom) {
        console.log('User tapped Custom Button: ', response.customButtom);
      } else {
        setImageUri(response.assets[0].uri);
        setSowModal(false);
      }
    });
  };
  const FavOp = () => {
    if (favourite === 0) {
      setFavourite(1);
      setColor('black');
    } else if (favourite === 1) {
      setFavourite(0);
      setColor('white');
    } else if (colour === 'white') {
      setFavourite(1);
      setColor('black');
    } else {
      setFavourite(0);
      setColor('white');
    }
  };
  return (
    <View style={styles.main}>
      <View style={styles.inputContainer}>
        <Modal transparent={true} visible={showModal} animationType="slide">
          <View style={styles.topView}>
            <View style={[styles.modalView]}>
              <Pressable onPress={() => setSowModal(false)}>
                <Entypo
                  name="cross"
                  size={30}
                  color="red"
                  backgroundColor="'#33363D"
                  style={styles.cancelModal}
                />
              </Pressable>
              <Text style={styles.modalText}>Upload Image</Text>
              <Pressable
                style={styles.modalButton}
                onPress={() => OpenGallery()}>
                <Text style={styles.modalText}>Open Gallery</Text>
              </Pressable>
              <Pressable
                style={styles.modalButton}
                onPress={() => OpenCamera()}>
                <Text style={styles.modalText}>Open Camera</Text>
              </Pressable>
            </View>
          </View>
        </Modal>
        <Pressable
          style={styles.userIcon}
          onPress={() => setSowModal(!showModal)}>
          <ImageBackground source={require('../Assest/R.png')}>
            <Image source={{uri: imageUri}} style={styles.imageBack} />
          </ImageBackground>
        </Pressable>
        <Pressable style={styles.imageStyleStar} onPressIn={() => FavOp()}>
          <FontAwesome
            style={styles.favouriteIcon}
            name="star"
            size={50}
            color={colour}
          />
        </Pressable>
      </View>
      <View>
        <View style={styles.container}>
          <View style={styles.inputContainer}>
            <Text style={styles.textMargin}>Name</Text>
            <TextInput
              style={styles.textInput}
              variant="filled"
              placeholder="Enter Your Name"
              // eslint-disable-next-line react/no-unstable-nested-components
              trailing={() => (
                <FontAwesome name="user" size={25} color="black" />
              )}
              autoCorrect={false}
              autoComplete="off"
              autoCapitalize="words"
              value={name}
              onChangeText={text => setName(text)}
            />
          </View>
          {nameError ? (
            <Text style={styles.errorText}>Please Enter Valid Name</Text>
          ) : null}
          <View style={styles.inputContainer}>
            <Text style={styles.textMargin}>Moblie</Text>
            <TextInput
              style={styles.textInput}
              variant="filled"
              placeholder="Enter Your Mobile Number"
              // eslint-disable-next-line react/no-unstable-nested-components
              trailing={() => (
                <Ionicons name="md-call-outline" size={23} color="black" />
              )}
              value={mobile}
              onChangeText={text => setMobile(text)}
            />
          </View>
          {mobileError ? (
            <Text style={styles.errorText}>Please Enter Valid Mobile</Text>
          ) : null}
          <View style={styles.inputContainer}>
            <Text style={styles.textMargin}>Landline</Text>
            <TextInput
              style={styles.textInput}
              variant="filled"
              placeholder="Enter Your landline Number"
              // eslint-disable-next-line react/no-unstable-nested-components
              trailing={() => <Entypo name="landline" size={23} />}
              value={landline}
              onChangeText={text => setLandline(text)}
            />
          </View>
          {landlineError ? (
            <Text style={styles.errorText}>Please Enter Valid Landline</Text>
          ) : null}
        </View>
      </View>
      <View style={styles.containers}>
        <View style={[styles.inputContainer, styles.marginbtn]}>
          <Pressable onPressIn={() => UpdateUser()}>
            <Text style={[styles.btngen, styles.btnright]}>UPDATE</Text>
          </Pressable>
          <Pressable onPress={() => navigation.navigate('ContactList')}>
            <Text style={[styles.btngen, styles.btnleft]}>CANCEL</Text>
          </Pressable>
        </View>
      </View>
    </View>
  );
}
const styles = StyleSheet.create({
  main: {
    flex: 1,
    // backgroundColor: '#33363D',
    backgroundColor: 'aquamarine',
  },
  container: {
    marginTop: '13%',
    marginHorizontal: '3%',
  },
  containers: {
    marginHorizontal: '3%',
  },
  inputContainer: {flexDirection: 'row', marginTop: '3%'},
  textMargin: {flex: 0.35, marginTop: '2%', fontSize: 22, color: 'black'},
  textInput: {
    flex: 1,
    backgroundColor: 'black',
  },
  marginbtn: {
    marginTop: '50%',
  },
  btngen: {
    // backgroundColor: 'white',
    color: 'black',
    // paddingHorizontal: 52,
    paddingHorizontal: '12%',
    // paddingVertical: 15,
    paddingVertical: '4%',
    fontWeight: 'bold',
    borderRadius: 20,
    fontSize: 30,
    textAlign: 'center',
  },
  btnleft: {
    marginLeft: 10,
  },
  btnright: {
    marginRight: 10,
  },
  image: {
    // backgroundColor: 'red',
    alignContent: 'center',
  },
  userIcon: {
    marginLeft: 120,
  },
  userIcon1: {
    marginLeft: 100,
  },
  favouriteIcon: {
    marginLeft: 60,
    alignItems: 'center',
    alignContent: 'center',
    justifyContent: 'center',
  },
  imageStyleStar: {
    color: 'white',
    height: 50,
    borderRadius: 40,

    alignItems: 'center',
    alignContent: 'center',
    justifyContent: 'center',
  },
  topView: {
    // flex: 1,
    top: 500,
    alignContent: 'center',
  },
  modalView: {
    backgroundColor: 'grey',
    padding: 20,
    borderRadius: 20,
    shadowColor: 'black',
    // flexDirection: 'row',
    elevation: 5,
  },
  modalButton: {
    borderColor: 'black',
    borderWidth: 1,
    marginTop: 30,
    padding: 10,
    marginHorizontal: 30,
    borderRadius: 20,
  },
  modalText: {
    fontSize: 20,
    fontWeight: 'bold',
    color: 'orange',
    textAlign: 'center',
  },
  cancelModal: {
    marginLeft: 320,
    borderRadius: 20,
  },
  imageBack: {
    height: 160,
    width: 160,
    // borderRadius: 170,
    borderWidth: 2,
    // borderColor: 'red',
    // position: 'relative',
  },
  errorText: {
    color: 'red',
    marginLeft: 100,
  },
});
export default UpdateContact;
