/* Components */
// import { Providers } from '@/lib/providers';
import Footer from './components/footer'
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
            <Footer/>
          </section>
        </body>
      </html>
    // </Providers>
  )
}
