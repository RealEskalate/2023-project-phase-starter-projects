/* Components */
// import { Providers } from '@/lib/providers';
import Header from './components/header'

/* Instruments */
import './styles/globals.css'

export default function RootLayout(props: React.PropsWithChildren) {
  return (
    // <Providers>
      <html lang="en">
        <body>
          <section>
            <Header/>
            <main>{props.children}</main>
            <footer >
              <h1>Footer</h1>
            </footer>
          </section>
        </body>
      </html>
    // </Providers>
  )
}
