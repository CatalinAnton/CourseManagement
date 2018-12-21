import {
  GET_RESOURCES,
  SET_RESOURCES,
  POST_RESOURCE
} from './resources.constants'

export const getResources = (payload, resolve, reject) => ({
  type: GET_RESOURCES,
  payload: { resolve, reject }
})

export const setResources = resources => ({
  type: SET_RESOURCES,
  payload: { resources }
})

export const postResource = (resource, resolve, reject) => ({
  type: POST_RESOURCE,
  payload: { resource, resolve, reject }
})
