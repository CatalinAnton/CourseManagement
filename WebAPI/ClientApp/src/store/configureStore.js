import { applyMiddleware, combineReducers, compose, createStore } from 'redux'
import createSagaMiddleware from 'redux-saga'
import reducers from './rootReducer'
import rootSaga from './rootSaga'
import { routerReducer, routerMiddleware } from 'react-router-redux'

export default (history, initialState) => {
  const sagaMiddleware = createSagaMiddleware()

  const middleware = [sagaMiddleware, routerMiddleware(history)]

  // In development, use the browser's Redux dev tools extension if installed
  const enhancers = []
  const isDevelopment = process.env.NODE_ENV === 'development'
  if (
    isDevelopment &&
    typeof window !== 'undefined' &&
    window.__REDUX_DEVTOOLS_EXTENSION__
  ) {
    enhancers.push(window.__REDUX_DEVTOOLS_EXTENSION__())
  }

  const rootReducer = combineReducers({
    ...reducers,
    routing: routerReducer
  })

  const store = createStore(
    rootReducer,
    initialState,
    compose(
      applyMiddleware(...middleware),
      ...enhancers
    )
  )

  sagaMiddleware.run(rootSaga)  
  return store
}
