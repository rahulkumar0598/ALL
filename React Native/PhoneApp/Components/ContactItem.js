/* eslint-disable prettier/prettier */
/* eslint-disable react/react-in-jsx-scope */
import {useNavigation} from '@react-navigation/native';
import {Pressable, StyleSheet, Text, View, Animated, Image} from 'react-native';
import {Swipeable} from 'react-native-gesture-handler';
import {getColorByLetter} from '../Assest/colors';
const ContactItem = prop => {
  const navigation = useNavigation();

  const leftSwipe = (progress, dragX) => {
    const scale = dragX.interpolate({
      inputRange: [0, 100],
      outputRange: [0, 2],
      extrapolate: 'clamp',
    });
    return (
      <Pressable onPressIn={prop.deleteContact} activeOpacity={0.6}>
        <View style={styles.deleteBox}>
          <Animated.Text style={{transform: [{scale: scale}]}}>
            Delete
          </Animated.Text>
        </View>
      </Pressable>
    );
  };
  return (
    <Swipeable renderLeftActions={leftSwipe}>
      <Pressable
        onPress={() =>
          navigation.navigate('UpdateContact', {
            data: {
              name: prop.data.name,
              mobile: prop.data.mobile,
              landline: prop.data.landline,
              favourite: prop.data.favourite,
              colour: prop.data.colour,
              image: prop.data.image,
              id: prop.data.contact_id,
            },
          })
        }>
        <View style={styles.userItem}>
          {prop.data.image ? (
            <Image source={{uri: prop.data.image}} style={[styles.photo]} />
          ) : (
            <Text
              style={[
                styles.textStyle,
                styles.textStyleImage,
                {
                  backgroundColor: getColorByLetter(prop.data.name[0]),
                },
              ]}>
              {prop.data.name[0]}
            </Text>
          )}

          <Text style={[styles.textStyle, styles.textStyleName]}>
            {prop.data.name}
          </Text>
        </View>
      </Pressable>
    </Swipeable>
  );
};

const styles = StyleSheet.create({
  userItem: {
    width: '95%',
    // backgroundColor: '#fff',
    backgroundColor: 'cyan',
    marginBottom: 5,
    // flex: 1,
    flexDirection: 'row',
    borderRadius: 50,
    marginLeft: 10,
  },
  textStyle: {
    color: 'black',
    fontSize: 20,
    marginVertical: 20,
    textAlign: 'center',
    alignItems: 'center',
    justifyContent: 'center',
    paddingTop: 10,
  },
  textStyleImage: {
    marginLeft: 30,
    marginRight: 40,
    paddingLeft: 7,
    paddingRight: 7,
    borderRadius: 30,
    fontSize: 20,
    width: 50,
    height: 50,
  },
  photo: {
    alignContent: 'center',
    paddingTop: 10,
    marginVertical: 20,
    marginLeft: 30,
    marginRight: 40,
    paddingLeft: 7,
    paddingRight: 7,
    borderRadius: 30,
    width: 50,
    height: 50,
  },
  photoStyle: {},
  textStyleName: {
    marginHorizontal: 10,
  },
  deleteBox: {
    marginLeft: 30,
    backgroundColor: 'red',
    justifyContent: 'center',
    alignItems: 'center',
    width: 100,
    height: '94%',
    borderTopStartRadius: 30,
    borderBottomStartRadius: 30,
    // borderWidth: 1,
    shadowColor: 'blue',
    elevation: 5,
    shadowRadius: 5,
  },
  //   containerIn: {
  //     height: 80,
  //     backgroundColor: 'white',
  //     justifyContent: 'center',
  //     padding: 16,
  //   },
});
export default ContactItem;
