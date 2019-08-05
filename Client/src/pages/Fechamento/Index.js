import React, { Component } from "react"
import styled from "styled-components/native"
import Icon from "react-native-vector-icons/MaterialIcons"
import { ToastAndroid } from "react-native"

import FechamentoService from "../../services/FechamentoService"
import DateHelper from "../../helpers/DateHelper"
import DateTimePiker from "../../helpers/Components/DateTimePicker"

export default class Relatorio extends Component {
  constructor() {
    super()
    this.FechamentoService = new FechamentoService()
    this.state = { relatorios: [], dateSearch: new Date() }
  }

  componentDidMount() {
    this._carregaAtividades()
  }

  async _carregaAtividades() {
    try {
      var relatorios = await this.FechamentoService.buscaTotasAtividadesSemana(
        this.state.dateSearch
      )
      this.setState({ relatorios: relatorios.relatorioPorDia })
    } catch (error) {
      ToastAndroid.show(error.message, ToastAndroid.LONG)
    }
  }

  render() {
    return (
      <Container>
        <Search>
          <SearchInput>
            <DateTimePiker
              value={this.state.dateSearch}
              onSelectDate={date => this.setState({ dateSearch: date })}
              color="#000"
            />
          </SearchInput>
          <SearchBottom onPress={() => this._carregaAtividades()}>
            <Icon name="search" size={22} color="#000" />
          </SearchBottom>
        </Search>
        <ContainerRelatorioItem>
          <HeaderItem>
            <HeaderLeft>
              <Atividades>Valor Total</Atividades>
            </HeaderLeft>
            <HeaderRight>
              <Valor>
                R${" "}
                {this.state.relatorios
                  .reduce((a, b) => a + b.reduce((a, b) => a + b.Valor, 0), 0)
                  .toFixed(2)}
              </Valor>
            </HeaderRight>
          </HeaderItem>
        </ContainerRelatorioItem>

        {this.state.relatorios.map((relatoriosDia, index) => {
          return <RelatorioItem relatoriosDia={relatoriosDia} key={index} />
        })}
      </Container>
    )
  }
}

class RelatorioItem extends Component {
  constructor() {
    super()
    this.state = { show: false, icon: "expand-more" }
  }

  showBody(relatorios) {
    if (this.state.show) {
      return (
        <BodyItem>
          {relatorios.map((relatorio, index) => (
            <Item key={index}>
              <NomeAtividade>{relatorio.Nome}</NomeAtividade>
              <ValorAtividade>R$ {relatorio.Valor.toFixed(2)}</ValorAtividade>
            </Item>
          ))}
        </BodyItem>
      )
    }
  }

  togleBody() {
    this.setState({ show: !this.state.show })
    if (this.state.icon == "expand-more") this.setState({ icon: "expand-less" })
    else this.setState({ icon: "expand-more" })
  }

  render() {
    const relatorios = this.props.relatoriosDia
    return (
      <ContainerRelatorioItem>
        <HeaderItem onPress={() => this.togleBody()}>
          <HeaderLeft>
            <HeaderLeftSuperior>
              <Data>
                {DateHelper.dateToExtensiveString(relatorios[0].DataRealizada)}
              </Data>
            </HeaderLeftSuperior>
            <HeaderLeftInferior>
              <Atividades>
                <NumeroAtividades>{relatorios.length} </NumeroAtividades>
                atividades
              </Atividades>
              <Valor>
                R$ {relatorios.reduce((a, b) => a + b.Valor, 0).toFixed(2)}
              </Valor>
            </HeaderLeftInferior>
          </HeaderLeft>
          <HeaderRight>
            <Icon name={this.state.icon} size={40} color="#000" />
          </HeaderRight>
        </HeaderItem>
        {this.showBody(relatorios)}
      </ContainerRelatorioItem>
    )
  }
}

const Container = styled.ScrollView.attrs({
  contentContainerStyle: {
    paddingTop: 15
  }
})`
  background-color: #493f85;
  padding-bottom: 15px;
`

const ContainerRelatorioItem = styled.View`
  margin-left: 20px;
  margin-right: 20px;
  margin-top: 5px;
  background: #fff;
  border-radius: 0.5;
`

///// Search #Search

const Search = styled.View`
  margin: 20px;
  margin-top: 0px;
  margin-bottom: 0px;
  flex-direction: row;
  justify-content: space-between;
  align-items: center;
  background: #fff;
`

const SearchInput = styled.View`
  flex: 15;
`

const SearchBottom = styled.TouchableOpacity`
  flex: 1;
  padding: 20px;
`

///// Body #Body
const BodyItem = styled.View`
  margin-left: 20px;
  margin-right: 20px;
  margin-bottom: 10px;
`
const Item = styled.View`
  background: rgba(73, 63, 133, 0.2);
  padding: 10px;
  margin-bottom: 10px;
  flex-direction: row;
  justify-content: space-between;
`
const NomeAtividade = styled.Text`
  font-size: 16;
  color: rgb(73, 63, 133);
`
const ValorAtividade = styled.Text`
  font-size: 16;
  color: rgb(73, 63, 133);
`

///// Header #Header
const HeaderItem = styled.TouchableOpacity`
  flex-direction: row;
  justify-content: space-between;
  margin: 10px;
`

const HeaderLeft = styled.View`
  flex-direction: column;
  width: 80%;
`

const HeaderLeftSuperior = styled.View``

const HeaderLeftInferior = styled.View`
  flex-direction: row;
  justify-content: space-between;
`

const HeaderRight = styled.View`
  flex-direction: row;
  align-items: flex-end;
`

const Data = styled.Text`
  font-size: 17;
  color: #000;
`
const Atividades = styled.Text`
  font-size: 16;
  color: #000;
`
const NumeroAtividades = styled.Text`
  font-size: 16px;
  font-weight: bold;
`
const Valor = styled.Text`
  font-size: 16px;
  font-weight: bold;
  color: #000;
`
