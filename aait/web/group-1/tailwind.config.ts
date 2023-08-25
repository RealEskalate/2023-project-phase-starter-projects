import type { Config } from 'tailwindcss'

const config: Config = {
  content: [
    './pages/**/*.{js,ts,jsx,tsx,mdx}',
    './components/**/*.{js,ts,jsx,tsx,mdx}',
    './app/**/*.{js,ts,jsx,tsx,mdx}',
  ],
  theme: {
    extend: {
      colors: {
        'blue-first': '#264FAD',
        'field-background-color': '#FDFEFF',
        'primary-color': '#264FAD',
        'dark-blue': '#160041',
        'light-gray': '#424242', 
        'black-text-color': '#363636',
        'light-text-color': '#7D7D7D',
        'home-card-gray-bg': '#F6F6FC',
        'deep-gray': '#37474F',
      },
      screens: {
        'mobile': '375px', 
        'tablet': '768px', 
        'laptop': '1024px', 
        'desktop': '1440px', 
      },
    },
  },
  plugins: [],
}
export default config