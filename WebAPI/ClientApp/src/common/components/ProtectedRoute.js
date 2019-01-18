import React from 'react'
import { connect } from 'react-redux'
import { Route, Redirect } from 'react-router-dom'

import { selectAuthentified } from '../../auth'

const ProtectedRoute = ({ authenticated, component: Component, ...rest }) => (
  <Route {...rest} render={(props) => ( console.log(authenticated) ||
    authenticated === true
      ? <Component {...props} />
      : <Redirect to='/' />
    )}
  />
)

const mapStateToProps = state => ({
  authenticated: selectAuthentified(state)
})

export default connect(mapStateToProps, null)(ProtectedRoute)