'use client'

import React, {ReactNode} from 'react'
import { Provider } from 'react-redux'
import { store } from '../../store/index'

interface Props {
    children?: ReactNode
}

const StateProvider = ({children}:Props) => {
  return (
    <Provider store={store}>
        {children}
    </Provider>
  )
}

export default StateProvider