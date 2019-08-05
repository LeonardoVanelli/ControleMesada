import React, { Component } from "react"
import { DatePickerAndroid, StyleSheet } from "react-native"
import styled from "styled-components/native"
import Icon from "react-native-vector-icons/FontAwesome"

import DateHelper from "../DateHelper"

export default class DateTimePicker extends Component {
  constructor(props) {
    super()
    this._OpenDatePicker = this._OpenDatePicker.bind(this)
  }

  async _OpenDatePicker() {
    try {
      const { action, year, month, day } = await DatePickerAndroid.open({
        date: this.props.field
      })
      if (action !== DatePickerAndroid.dismissedAction) {
        let date = new Date(year, month, day)
        this.setState({ field: date })
        this.props.onSelectDate(date)
      }
    } catch ({ code, message }) {
      console.warn("Cannot open date picker", message)
    }
  }

  render() {
    return (
      <TextInputWithoutCursor
        onPress={() => this._OpenDatePicker()}
        {...this.props}
      />
    )
  }
}

//testes
class TextInputWithoutCursor extends Component {
  render() {
    return (
      <Container>
        <Input onPress={() => this.props.onPress()}>
          <InputText color={this.props.color}>
            {DateHelper.dateToExtensiveString(this.props.value)}
          </InputText>
          <Icon
            name="table"
            color={this.props.color}
            size={20}
            style={{ marginRight: 15 }}
          />
        </Input>
      </Container>
    )
  }
}

const Container = styled.View``

const Input = styled.TouchableOpacity`
  flex-direction: row;
  align-items: center;
  justify-content: space-between;
`

const InputText = styled.Text.attrs({
  numberOfLines: 1
})`
  color: ${props => props.color || "#fff"};
  font-size: 14;
  padding-top: 15px;
  padding-bottom: 15px;
  padding-left: 10px;
  margin-right: 10px;
`
