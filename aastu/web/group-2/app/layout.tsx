/* Components */
// import { Providers } from '@/lib/providers';
import { Nav } from './components/Nav'

/* Instruments */
import './styles/globals.css'

export default function RootLayout(props: React.PropsWithChildren) {
  return (
    // <Providers>
      <html lang="en">
        <body>
          <section>
            <Nav />

            <header>
              <h1> Header </h1>
            </header>

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
