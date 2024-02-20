import '../style.css';
import Nav from '../components/Nav'

export default function Application({Component, pageProps}) {
    return (
        <>
            <Nav />
            <Component {...pageProps} />
        </>
    )
}