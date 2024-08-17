/**
 * Sample React Native App
 * https://github.com/facebook/react-native
 *
 * @format
 */

import {createNativeStackNavigator} from '@react-navigation/native-stack';
import {NavigationContainer} from '@react-navigation/native';
import React from 'react';
import Drawer from './Components/Drawer';
import CreateContact from './Components/CreateContact';
import UpdateContact from './Components/UpdateContact';
// import Search from './Components/Search';
const stack = createNativeStackNavigator();
function App() {
  return (
    <NavigationContainer>
      <stack.Navigator
        screenOptions={{
          headerTitleAlign: 'center',
          headerStyle: {backgroundColor: 'lime'},
        }}>
        <stack.Screen
          name="Drawer"
          component={Drawer}
          options={{headerShown: false}}
        />
        <stack.Screen
          name="CreateContact"
          component={CreateContact}
          options={{
            title: 'Add New Contact',
          }}
        />
        <stack.Screen
          name="UpdateContact"
          component={UpdateContact}
          options={{title: 'Update Contact'}}
        />
        {/* <stack.Screen
          name="Search"
          component={Search}
          options={{title: 'Search'}}
        /> */}
      </stack.Navigator>
    </NavigationContainer>
  );
}

export default App;
