import React, { Fragment } from 'react'
import { Route } from 'react-router'
// import ProtectedRoute from './common/components/ProtectedRoute'
import { Domain } from './screens'

export default () => (
  <Fragment>
    <Route exact path="/" component={Domain} />
    {/* <ProtectedRoute exact path="/student" component={StudentHomePage} /> */}
  </Fragment>
)
