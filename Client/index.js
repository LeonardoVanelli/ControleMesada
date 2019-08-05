/**
 * @format
 */

import { AppRegistry } from "react-native"
import AsyncStorage from "@react-native-community/async-storage"
import { name as appName } from "./app.json"
import { createStackNavigator, createAppContainer } from "react-navigation"
/**  Pages  */
import AtividadeIndex from "./src/pages/Atividade/index"
import HomeIndex from "./src/pages/home/index"
import LoginIndex from "./src/pages/Login/index"
import AtividadeCreateIndex from "./src/pages/Atividade/Create"
import Relatorio from "./src/pages/Fechamento/Index"

import Pessoa from "./src/models/Pessoa.js"

let pessoa = new Pessoa(
  2,
  "Gustavo Luis dos Santos",
  "gustavo123@gmail.com",
  "Gustado Santos"
)
AsyncStorage.setItem("@UsuarioLogado", JSON.stringify(pessoa)).catch(err =>
  console.log(err)
)

const AppNavigator = createStackNavigator(
  {
    Login: {
      screen: LoginIndex,
      navigationOptions: {
        title: "Login"
      }
    },
    Atividades: {
      screen: AtividadeIndex,
      navigationOptions: {
        title: "Atividades"
      }
    },
    AtividadesCreate: {
      screen: AtividadeCreateIndex,
      navigationOptions: {
        title: "Nova Atividade"
      }
    },
    Relatorio: {
      screen: Relatorio,
      navigationOptions: {
        title: "Relatório",
        headerTransparent: false
      }
    },

    Home: {
      screen: HomeIndex,
      navigationOptions: {
        title: "Home",
        headerTransparent: true
      }
    }
  },
  {
    initialRouteName: "Home"
  }
)

AppRegistry.registerComponent(appName, () => createAppContainer(AppNavigator))
