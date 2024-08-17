/**
 * Sample React Native App
 * https://github.com/facebook/react-native
 *
 * @format
 */

import React from 'react';
import {createNativeStackNavigator} from '@react-navigation/native-stack';
import {NavigationContainer} from '@react-navigation/native';
import BudgetEntry from './Components/BudgetEntry';
import BudgetListing from './Components/BudgetListing';
import BudgetUpdate from './Components/BudgetUpdate';

const stack = createNativeStackNavigator();
function App(): JSX.Element {
  return (
    <NavigationContainer>
      <stack.Navigator
        screenOptions={{
          headerStyle: {backgroundColor: 'orange'},
          headerTitleAlign: 'center',
        }}>
        <stack.Screen
          name="BudgetEntry"
          component={BudgetEntry}
          options={{title: 'Budget Entry'}}
        />
        <stack.Screen
          name="BudgetListing"
          component={BudgetListing}
          options={{title: 'Budget Listing'}}
        />
        <stack.Screen
          name="BudgetUpdate"
          component={BudgetUpdate}
          options={{title: 'Budget Update'}}
        />
      </stack.Navigator>
    </NavigationContainer>
  );
}

export default App;
