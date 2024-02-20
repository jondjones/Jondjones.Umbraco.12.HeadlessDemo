import Link from 'next/link'

const Nav = () => {
    return (
         <nav className="nav">
            <div className="container">
                <h1 className="logo">
                    <a href="#">My Website</a>
                </h1>
                <ul>
                    <li>
                        <Link href="/">
                            Home
                        </Link>
                    </li>
                    <li>
                        <Link href="/listing">
                            Listing Page
                        </Link>
                    </li>
                    <li>
                        <Link href="/richtext">
                            Richtext Property
                        </Link>
                    </li>
                </ul>
            </div>
        </nav>
    )
}

export default Nav;