import ReduxProvider from '@/lib/providers';
import './globals.css';
import type { Metadata } from 'next';
import Footer from './components/footer';
import Header from './components/header';

export const metadata: Metadata = {
  title: 'Create Next App',
  description: 'Generated by create next app',
};

export default function RootLayout({ children }: { children: React.ReactNode }) {
  return (
    <html lang="en" className='scroll-smooth'>
      <body className="bg-white dark:bg-dark-background dark:text-dark-textColor-50 transition-colors ease-linear">
        <ReduxProvider>
          <Header />
          {children}
          <Footer />
        </ReduxProvider>
      </body>
    </html>
  );
}
