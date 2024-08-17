/* eslint-disable prettier/prettier */
import React from 'react';
import {createDrawerNavigator} from '@react-navigation/drawer';
import ContactList from './ContactList';
import Favourite from './Favourite';
// import Practice from './CreatePractice';

const drwaer = createDrawerNavigator();

function Drawer(): JSX.Element {
  return (
    <drwaer.Navigator
      screenOptions={{
        headerTitleAlign: 'center',
        headerStyle: {backgroundColor: 'lime'},
      }}>
      <drwaer.Screen
        name="ContactList"
        component={ContactList}
        options={{
          title: 'Contact List',
        }}
      />
      <drwaer.Screen
        name="FavouriteList"
        component={Favourite}
        options={{title: 'Favourite List'}}
      />
      {/* <drwaer.Screen
        name="Practice"
        component={Practice}
        options={{title: 'Practice'}}
      /> */}
    </drwaer.Navigator>
  );
}
export default Drawer;
