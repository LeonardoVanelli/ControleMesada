import React, {Component} from 'react';
import {ScrollView, FlatList, StyleSheet, Text, View, Button, RefreshControl} from 'react-native';
import AtividadeService from '../../services/AtividadeService';
import DataHelper from '../../helpers/DateHelper';
import AtividadeController from '../../controller/AtividadeController'

export default class App extends Component {

  constructor() {

    super()
    this.AtividadeService = new AtividadeService()
    this.state = {atividades: []}
    this.AtividadeController = new AtividadeController()
  }

  componentDidMount() {

    this.AtividadeController.AtualizaListaTarefa()
      .then(atividades => {
        this.setState({atividades})
      })    
  }

  _onRefresh = () => {

    this.setState({refreshing: true});
    this.AtividadeController.AtualizaListaTarefa()
    .then(atividades => {
      this.setState({atividades})
      this.setState({refreshing: false})
    }) 
  }

  render() {
    return (
      <View style={styles.container}>
        <Button          
          title='Novo'
          onPress={() => this.props.navigation.navigate('AtividadesCreate')}
        />
        <ScrollView
          refreshControl={
            <RefreshControl
              refreshing={this.state.refreshing}
              onRefresh={this._onRefresh}
            />
          }
        >         
          <FlatList
            keyExtractor={(item) => item.Id.toString()}      
            data={this.state.atividades}          
            renderItem={item => {
              let atividade = item.item
              return (
                <View style={styles.item}>
                  <View style={styles.tarefaPessoa}>
                    <Text style={styles.text}>{atividade.Pessoa.Nome}</Text>                  
                    <Text style={styles.text}>{atividade.Tarefa.Nome}</Text>
                  </View>
                  <Text style={styles.text}>{DataHelper.dateToExtensiveString(atividade.DataRealizada)}</Text>    
                </View>
              )
          }}
          />
        </ScrollView>
      </View>
    );
  }
}

const styles = StyleSheet.create({  
  container: {
    flex: 1,
    backgroundColor: '#493F85',
  },
  item: {    
    flexDirection: 'column',
    borderBottomWidth: 1,
    borderColor: 'white',
    marginLeft: 10,
    marginRight: 10,
    marginBottom: 5,
  },
  tarefaPessoa: {
    flexDirection: 'row',
    justifyContent: 'space-between',
  },
  text: {
    fontSize: 20,
    color: 'white'
  },  
});
