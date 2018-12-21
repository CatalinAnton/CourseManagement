import React from 'react'
import styled from 'styled-components'
import { constants } from '../'

export default ({ padding, ...rest }) => <Input {...rest} padding={padding} />

const Input = styled.input`
`
