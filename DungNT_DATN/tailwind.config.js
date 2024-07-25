/** @type {import('tailwindcss').Config} */
export default {
  content: ["./index.html", "./src/**/**/*.{js,ts,jsx,tsx}"],
  theme: {
    extend: {
      colors: {
        colorthemes: "#085BA4",
        white: "#fff",
        line: "#d3cfcf",
        success: "#3e8522",
        error: "#f44336",
        pendding: "#d9512c",
      },
    },
  },
  plugins: [],
};
