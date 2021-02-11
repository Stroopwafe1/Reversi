using NUnit.Framework;
using ReversiRestAPI;

namespace ReversiRestAPITests {
    [TestFixture]
    public class GameTest {
        // geen kleur = 0
        // White = 1
        // Black = 2
        [Test]
        public void PossibleMove_BuitenBoard_ReturnFalse() {
            // Arrange
            Game game = new Game();
            // 0 1 2 3 4 5 6 7
            // v
            // 0 0 0 0 0 0 0 0 0
            // 1 0 0 0 0 0 0 0 0
            // 2 0 0 0 0 0 0 0 0
            // 3 0 0 0 1 2 0 0 0
            // 4 0 0 0 2 1 0 0 0
            // 5 0 0 0 0 0 0 0 0
            // 6 0 0 0 0 0 0 0 0
            // 7 0 0 0 0 0 0 0 0
            // 1 <
            // Act
            game.Turn = Colour.White;
            var actual = game.PossibleMove(8, 8);
            // Assert
            Assert.IsFalse(actual);
        }
        [Test]
        public void PossibleMove_StartSituatieZet23Black_ReturnTrue() {
            // Arrange
            Game game = new Game();
            // 0 1 2 3 4 5 6 7
            // v
            // 0 0 0 0 0 0 0 0 0
            // 1 0 0 0 0 0 0 0 0
            // 2 0 0 0 2 0 0 0 0 <
            // 3 0 0 0 1 2 0 0 0
            // 4 0 0 0 2 1 0 0 0
            // 5 0 0 0 0 0 0 0 0
            // 6 0 0 0 0 0 0 0 0
            // 7 0 0 0 0 0 0 0 0
            // Act
            game.Turn = Colour.Black;
            var actual = game.PossibleMove(2, 3);
            // Assert
            Assert.IsTrue(actual);
        }

        [Test]
        public void PossibleMove_StartSituatieZet23White_ReturnFalse() {
            // Arrange
            Game game = new Game();
            // 0 1 2 3 4 5 6 7
            // v
            // 0 0 0 0 0 0 0 0 0
            // 1 0 0 0 0 0 0 0 0
            // 2 0 0 0 1 0 0 0 0 <
            // 3 0 0 0 1 2 0 0 0
            // 4 0 0 0 2 1 0 0 0
            // 5 0 0 0 0 0 0 0 0
            // 6 0 0 0 0 0 0 0 0
            // 7 0 0 0 0 0 0 0 0
            // Act
            game.Turn = Colour.White;
            var actual = game.PossibleMove(2, 3);
            // Assert
            Assert.IsFalse(actual);
        }
        [Test]
        public void PossibleMove_ZetAanDeRandBoven_ReturnTrue() {
            // Arrange
            Game game = new Game();
            game.Board[1, 3] = Colour.White;
            game.Board[2, 3] = Colour.White;
            // 0 1 2 3 4 5 6 7
            // v
            // 0 0 0 0 2 0 0 0 0 <
            // 1 0 0 0 1 0 0 0 0
            // 2 0 0 0 1 0 0 0 0
            // 3 0 0 0 1 2 0 0 0
            // 4 0 0 0 2 1 0 0 0
            // 5 0 0 0 0 0 0 0 0
            // 6 0 0 0 0 0 0 0 0
            // 7 0 0 0 0 0 0 0 0
            // Act
            game.Turn = Colour.Black;
            var actual = game.PossibleMove(0, 3);
            // Assert
            Assert.IsTrue(actual);
        }

        [Test]
        public void PossibleMove_ZetAanDeRandBoven_ReturnFalse() {
            // Arrange
            Game game = new Game();
            game.Board[1, 3] = Colour.White;
            game.Board[2, 3] = Colour.White;
            // 0 1 2 3 4 5 6 7
            // v
            // 0 0 0 0 1 0 0 0 0 <
            // 1 0 0 0 1 0 0 0 0
            // 2 0 0 0 1 0 0 0 0
            // 3 0 0 0 1 2 0 0 0
            // 4 0 0 0 2 1 0 0 0
            // 5 0 0 0 0 0 0 0 0
            // 6 0 0 0 0 0 0 0 0
            // 7 0 0 0 0 0 0 0 0
            // Act
            game.Turn = Colour.White;
            var actual = game.PossibleMove(0, 3);
            // Assert
            Assert.IsFalse(actual);
        }
        [Test]
        public void PossibleMove_ZetAanDeRandBovenEnTotBenedenReedsGevuld_ReturnTrue() {
            // Arrange
            Game game = new Game();
            game.Board[1, 3] = Colour.White;
            game.Board[2, 3] = Colour.White;
            game.Board[3, 3] = Colour.White;
            game.Board[4, 3] = Colour.White;
            game.Board[5, 3] = Colour.White;
            game.Board[6, 3] = Colour.White;
            game.Board[7, 3] = Colour.Black;
            // 0 1 2 3 4 5 6 7
            // v
            // 0 0 0 0 2 0 0 0 0 <
            // 1 0 0 0 1 0 0 0 0
            // 2 0 0 0 1 0 0 0 0
            // 3 0 0 0 1 2 0 0 0
            // 4 0 0 0 1 1 0 0 0
            // 5 0 0 0 1 0 0 0 0
            // 6 0 0 0 1 0 0 0 0
            // 7 0 0 0 2 0 0 0 0
            // Act
            game.Turn = Colour.Black;
            var actual = game.PossibleMove(0, 3);
            // Assert
            Assert.IsTrue(actual);
        }
        [Test]
        public void PossibleMove_ZetAanDeRandBovenEnTotBenedenReedsGevuld_ReturnFalse() {
            // Arrange
            Game game = new Game();
            game.Board[1, 3] = Colour.White;
            game.Board[2, 3] = Colour.White;
            game.Board[3, 3] = Colour.White;
            game.Board[4, 3] = Colour.White;
            game.Board[5, 3] = Colour.White;
            game.Board[6, 3] = Colour.White;
            game.Board[7, 3] = Colour.White;
            // 0 1 2 3 4 5 6 7
            // v
            // 0 0 0 0 2 0 0 0 0 <
            // 1 0 0 0 1 0 0 0 0
            // 2 0 0 0 1 0 0 0 0
            // 3 0 0 0 1 2 0 0 0
            // 4 0 0 0 1 1 0 0 0
            // 5 0 0 0 1 0 0 0 0
            // 6 0 0 0 1 0 0 0 0
            // 7 0 0 0 1 0 0 0 0
            // Act
            game.Turn = Colour.Black;
            var actual = game.PossibleMove(0, 3);
            // Assert
            Assert.IsFalse(actual);
        }
        [Test]
        public void PossibleMove_ZetAanDeRandRechts_ReturnTrue() {
            // Arrange
            Game game = new Game();
            game.Board[4, 5] = Colour.White;
            game.Board[4, 6] = Colour.White;
            // 0 1 2 3 4 5 6 7
            // v
            // 0 0 0 0 2 0 0 0 0
            // 1 0 0 0 1 0 0 0 0
            // 2 0 0 0 1 0 0 0 0
            // 3 0 0 0 1 2 0 0 0
            // 4 0 0 0 2 1 1 1 2 <
            // 5 0 0 0 0 0 0 0 0
            // 6 0 0 0 0 0 0 0 0
            // 7 0 0 0 0 0 0 0 0
            // Act
            game.Turn = Colour.Black;
            var actual = game.PossibleMove(4, 7);
            // Assert
            Assert.IsTrue(actual);
        }
        [Test]
        public void PossibleMove_ZetAanDeRandRechts_ReturnFalse() {
            // Arrange
            Game game = new Game();
            game.Board[4, 5] = Colour.White;
            game.Board[4, 6] = Colour.White;
            // 0 1 2 3 4 5 6 7
            // v
            // 0 0 0 0 1 0 0 0 0
            // 1 0 0 0 1 0 0 0 0
            // 2 0 0 0 1 0 0 0 0
            // 3 0 0 0 1 2 0 0 0
            // 4 0 0 0 2 1 1 1 1 <
            // 5 0 0 0 0 0 0 0 0
            // 6 0 0 0 0 0 0 0 0
            // 7 0 0 0 0 0 0 0 0
            // Act
            game.Turn = Colour.White;
            var actual = game.PossibleMove(4, 7);
            // Assert
            Assert.IsFalse(actual);
        }
        [Test]
        public void PossibleMove_ZetAanDeRandRechtsEnTotLinksReedsGevuld_ReturnTrue() {
            // Arrange
            Game game = new Game();
            game.Board[4, 0] = Colour.Black;
            game.Board[4, 1] = Colour.White;
            game.Board[4, 2] = Colour.White;
            game.Board[4, 3] = Colour.White;
            game.Board[4, 4] = Colour.White;
            game.Board[4, 5] = Colour.White;
            game.Board[4, 6] = Colour.White;
            // 0 1 2 3 4 5 6 7
            // v
            // 0 0 0 0 0 0 0 0 0
            // 1 0 0 0 0 0 0 0 0
            // 2 0 0 0 0 0 0 0 0
            // 3 0 0 0 1 2 0 0 0
            // 4 2 1 1 1 1 1 1 2 <
            // 5 0 0 0 0 0 0 0 0
            // 6 0 0 0 0 0 0 0 0
            // 7 0 0 0 0 0 0 0 0
            // Act
            game.Turn = Colour.Black;
            var actual = game.PossibleMove(4, 7);
            // Assert
            Assert.IsTrue(actual);
        }
        [Test]
        public void PossibleMove_ZetAanDeRandRechtsEnTotLinksReedsGevuld_ReturnFalse() {
            // Arrange
            Game game = new Game();
            game.Board[4, 0] = Colour.Black;
            game.Board[4, 1] = Colour.White;
            game.Board[4, 2] = Colour.White;
            game.Board[4, 3] = Colour.White;
            game.Board[4, 4] = Colour.White;
            game.Board[4, 5] = Colour.White;
            game.Board[4, 6] = Colour.White;
            // 0 1 2 3 4 5 6 7
            // v
            // 0 0 0 0 0 0 0 0 0
            // 1 0 0 0 0 0 0 0 0
            // 2 0 0 0 0 0 0 0 0
            // 3 0 0 0 1 2 0 0 0
            // 4 2 1 1 1 1 1 1 1 <
            // 5 0 0 0 0 0 0 0 0
            // 6 0 0 0 0 0 0 0 0
            // 7 0 0 0 0 0 0 0 0
            // Act
            game.Turn = Colour.White;
            var actual = game.PossibleMove(4, 7);
            // Assert
            Assert.IsFalse(actual);
        }
        // 0 1 2 3 4 5 6 7
        //
        // 0 0 0 0 0 0 0 0 0
        // 1 0 0 0 0 0 0 0 0
        // 2 0 0 0 0 0 0 0 0
        // 3 0 0 0 1 2 0 0 0
        // 4 0 0 0 2 1 0 0 0
        // 5 0 0 0 0 0 0 0 0
        // 6 0 0 0 0 0 0 0 0
        // 7 0 0 0 0 0 0 0 0
        [Test]
        public void PossibleMove_StartSituatieZet22White_ReturnFalse() {
            // Arrange
            Game game = new Game();
            // 0 1 2 3 4 5 6 7
            // v
            // 0 0 0 0 0 0 0 0 0
            // 1 0 0 0 0 0 0 0 0
            // 2 0 0 1 0 0 0 0 0 <
            // 3 0 0 0 1 2 0 0 0
            // 4 0 0 0 2 1 0 0 0
            // 5 0 0 0 0 0 0 0 0
            // 6 0 0 0 0 0 0 0 0
            // 7 0 0 0 0 0 0 0 0
            // Act
            game.Turn = Colour.White;
            var actual = game.PossibleMove(2, 2);
            // Assert
            Assert.IsFalse(actual);
        }
        [Test]
        public void PossibleMove_StartSituatieZet22Black_ReturnFalse() {
            // Arrange
            Game game = new Game();
            // 0 1 2 3 4 5 6 7
            // v
            // 0 0 0 0 0 0 0 0 0
            // 1 0 0 0 0 0 0 0 0
            // 2 0 0 2 0 0 0 0 0 <
            // 3 0 0 0 1 2 0 0 0
            // 4 0 0 0 2 1 0 0 0
            // 5 0 0 0 0 0 0 0 0
            // 6 0 0 0 0 0 0 0 0
            // 7 0 0 0 0 0 0 0 0
            // Act
            game.Turn = Colour.Black;
            var actual = game.PossibleMove(2, 2);
            // Assert
            Assert.IsFalse(actual);
        }
        [Test]
        public void PossibleMove_ZetAanDeRandRechtsBoven_ReturnTrue() {
            // Arrange
            Game game = new Game();
            game.Board[2, 5] = Colour.Black;
            game.Board[1, 6] = Colour.Black;
            game.Board[5, 2] = Colour.White;
            // 0 1 2 3 4 5 6 7
            // v
            // 0 0 0 0 0 0 0 0 1 <
            // 1 0 0 0 0 0 0 2 0
            // 2 0 0 0 0 0 2 0 0
            // 3 0 0 0 1 2 0 0 0
            // 4 0 0 0 2 1 0 0 0
            // 5 0 0 1 0 0 0 0 0
            // 6 0 0 0 0 0 0 0 0
            // 7 0 0 0 0 0 0 0 0
            // Act
            game.Turn = Colour.White;
            var actual = game.PossibleMove(0, 7);
            // Assert
            Assert.IsTrue(actual);
        }
        [Test]
        public void PossibleMove_ZetAanDeRandRechtsBoven_ReturnFalse() {
            // Arrange
            Game game = new Game();
            game.Board[2, 5] = Colour.Black;
            game.Board[1, 6] = Colour.Black;
            game.Board[5, 2] = Colour.White;
            //   0 1 2 3 4 5 6 7
            // v
            // 0 0 0 0 0 0 0 0 2 <
            // 1 0 0 0 0 0 0 2 0
            // 2 0 0 0 0 0 2 0 0
            // 3 0 0 0 1 2 0 0 0
            // 4 0 0 0 2 1 0 0 0
            // 5 0 0 1 0 0 0 0 0
            // 6 0 0 0 0 0 0 0 0
            // 7 0 0 0 0 0 0 0 0
            // Act
            game.Turn = Colour.Black;
            var actual = game.PossibleMove(0, 7);
            // Assert
            Assert.IsFalse(actual);
        }
        [Test]
        public void PossibleMove_ZetAanDeRandRechtsOnder_ReturnTrue() {
            // Arrange
            Game game = new Game();
            game.Board[2, 2] = Colour.Black;
            game.Board[5, 5] = Colour.White;
            game.Board[6, 6] = Colour.White;
            // 0 1 2 3 4 5 6 7
            // v
            // 0 0 0 0 0 0 0 0 0
            // 1 0 0 0 0 0 0 0 0
            // 2 0 0 2 0 0 0 0 0
            // 3 0 0 0 1 2 0 0 0
            // 4 0 0 0 2 1 0 0 0
            // 5 0 0 0 0 0 1 0 0
            // 6 0 0 0 0 0 0 1 0
            // 7 0 0 0 0 0 0 0 2 <
            // Act
            game.Turn = Colour.Black;
            var actual = game.PossibleMove(7, 7);
            // Assert
            Assert.IsTrue(actual);
        }
        [Test]
        public void PossibleMove_ZetAanDeRandRechtsOnder_ReturnFalse() {
            // Arrange
            Game game = new Game();
            game.Board[2, 2] = Colour.Black;
            game.Board[5, 5] = Colour.White;
            game.Board[6, 6] = Colour.White;
            // 0 1 2 3 4 5 6 7
            // v
            // 0 0 0 0 0 0 0 0 0 <
            // 1 0 0 0 0 0 0 0 0
            // 2 0 0 2 0 0 0 0 0
            // 3 0 0 0 1 2 0 0 0
            // 4 0 0 0 2 1 0 0 0
            // 5 0 0 0 0 0 1 0 0
            // 6 0 0 0 0 0 0 1 0
            // 7 0 0 0 0 0 0 0 1
            // Act
            game.Turn = Colour.White;
            var actual = game.PossibleMove(7, 7);
            // Assert
            Assert.IsFalse(actual);
        }
        [Test]
        public void PossibleMove_ZetAanDeRandLinksBoven_ReturnTrue() {
            // Arrange
            Game game = new Game();
            game.Board[1, 1] = Colour.White;
            game.Board[2, 2] = Colour.White;
            game.Board[5, 5] = Colour.Black;
            // 0 1 2 3 4 5 6 7
            // v
            // 0 2 0 0 0 0 0 0 0 <
            // 1 0 1 0 0 0 0 0 0
            // 2 0 0 1 0 0 0 0 0
            // 3 0 0 0 1 2 0 0 0
            // 4 0 0 0 2 1 0 0 0
            // 5 0 0 0 0 0 2 0 0
            // 6 0 0 0 0 0 0 0 0
            // 7 0 0 0 0 0 0 0 0
            // Act
            game.Turn = Colour.Black;
            var actual = game.PossibleMove(0, 0);
            // Assert
            Assert.IsTrue(actual);
        }
        [Test]
        public void PossibleMove_ZetAanDeRandLinksBoven_ReturnFalse() {
            // Arrange
            Game game = new Game();
            game.Board[1, 1] = Colour.White;
            game.Board[2, 2] = Colour.White;
            game.Board[5, 5] = Colour.Black;
            // 0 1 2 3 4 5 6 7
            // v
            // 0 1 0 0 0 0 0 0 0 <
            // 1 0 1 0 0 0 0 0 0
            // 2 0 0 1 0 0 0 0 0
            // 3 0 0 0 1 2 0 0 0
            // 4 0 0 0 2 1 0 0 0
            // 5 0 0 0 0 0 2 0 0
            // 6 0 0 0 0 0 0 0 0
            // 7 0 0 0 0 0 0 0 0
            // Act
            game.Turn = Colour.White;
            var actual = game.PossibleMove(0, 0);
            // Assert
            Assert.IsFalse(actual);
        }
        [Test]
        public void PossibleMove_ZetAanDeRandLinksOnder_ReturnTrue() {
            // Arrange
            Game game = new Game();
            game.Board[2, 5] = Colour.White;
            game.Board[5, 2] = Colour.Black;
            game.Board[6, 1] = Colour.Black;
            // 0 1 2 3 4 5 6 7
            // v
            // 0 0 0 0 0 0 0 0 0
            // 1 0 0 0 0 0 0 0 0
            // 2 0 0 0 0 0 1 0 0
            // 3 0 0 0 1 2 0 0 0
            // 4 0 0 0 2 1 0 0 0
            // 5 0 0 2 0 0 0 0 0
            // 6 0 2 0 0 0 0 0 0
            // 7 1 0 0 0 0 0 0 0 <
            // Act
            game.Turn = Colour.White;
            var actual = game.PossibleMove(7, 0);
            // Assert
            Assert.IsTrue(actual);
        }
        [Test]
        public void PossibleMove_ZetAanDeRandLinksOnder_ReturnFalse() {
            // Arrange
            Game game = new Game();
            game.Board[2, 5] = Colour.White;
            game.Board[5, 2] = Colour.Black;
            game.Board[6, 1] = Colour.Black;
            // 0 1 2 3 4 5 6 7
            // v
            // 0 0 0 0 0 0 0 0 0
            // 1 0 0 0 0 0 0 0 0
            // 2 0 0 0 0 0 1 0 0
            // 3 0 0 0 1 2 0 0 0
            // 4 0 0 0 2 1 0 0 0
            // 5 0 0 2 0 0 0 0 0
            // 6 0 2 0 0 0 0 0 0
            // 7 2 0 0 0 0 0 0 0 <
            // Act
            game.Turn = Colour.Black;
            var actual = game.PossibleMove(7, 0);
            // Assert
            Assert.IsFalse(actual);
        }
        //---------------------------------------------------------------------------
        [Test]
        public void DoMove_BuitenBoard_ReturnFalse() {
            // Arrange
            Game game = new Game();
            // 0 1 2 3 4 5 6 7
            // v
            // 0 0 0 0 0 0 0 0 0
            // 1 0 0 0 0 0 0 0 0
            // 2 0 0 0 0 0 0 0 0
            // 3 0 0 0 1 2 0 0 0
            // 4 0 0 0 2 1 0 0 0
            // 5 0 0 0 0 0 0 0 0
            // 6 0 0 0 0 0 0 0 0
            // 7 0 0 0 0 0 0 0 0
            // 1 <
            // Act
            game.Turn = Colour.White;
            var actual = game.DoMove(8, 8);
            // Assert
            Assert.IsFalse(actual);
            Assert.AreEqual(Colour.White, game.Board[3, 3]);
            Assert.AreEqual(Colour.White, game.Board[4, 4]);
            Assert.AreEqual(Colour.Black, game.Board[3, 4]);
            Assert.AreEqual(Colour.Black, game.Board[4, 3]);
            Assert.AreEqual(Colour.White, game.Turn);
        }
        [Test]
        public void DoMove_StartSituatieZet23Black_ReturnTrue() {
            // Arrange
            Game game = new Game();
            // 0 1 2 3 4 5 6 7
            // v
            // 0 0 0 0 0 0 0 0 0
            // 1 0 0 0 0 0 0 0 0
            // 2 0 0 0 2 0 0 0 0 <
            // 3 0 0 0 1 2 0 0 0
            // 4 0 0 0 2 1 0 0 0
            // 5 0 0 0 0 0 0 0 0
            // 6 0 0 0 0 0 0 0 0
            // 7 0 0 0 0 0 0 0 0
            // Act
            game.Turn = Colour.Black;
            var actual = game.DoMove(2, 3);
            // Assert
            Assert.IsTrue(actual);
            Assert.AreEqual(Colour.Black, game.Board[2, 3]);
            Assert.AreEqual(Colour.Black, game.Board[3, 3]);
            Assert.AreEqual(Colour.Black, game.Board[4, 3]);
            Assert.AreEqual(Colour.White, game.Turn);
        }

        [Test]
        public void DoMove_StartSituatieZet23White_ReturnFalse() {
            // Arrange
            Game game = new Game();
            // 0 1 2 3 4 5 6 7
            // v
            // 0 0 0 0 0 0 0 0 0
            // 1 0 0 0 0 0 0 0 0
            // 2 0 0 0 1 0 0 0 0 <
            // 3 0 0 0 1 2 0 0 0
            // 4 0 0 0 2 1 0 0 0
            // 5 0 0 0 0 0 0 0 0
            // 6 0 0 0 0 0 0 0 0
            // 7 0 0 0 0 0 0 0 0
            // Act
            game.Turn = Colour.White;
            var actual = game.DoMove(2, 3);
            // Assert
            Assert.IsFalse(actual);
            Assert.AreEqual(Colour.White, game.Board[3, 3]);
            Assert.AreEqual(Colour.White, game.Board[4, 4]);
            Assert.AreEqual(Colour.Black, game.Board[3, 4]);
            Assert.AreEqual(Colour.Black, game.Board[4, 3]);
            Assert.AreEqual(Colour.None, game.Board[2, 3]);
            Assert.AreEqual(Colour.White, game.Turn);
        }
        [Test]
        public void DoMove_ZetAanDeRandBoven_ReturnTrue() {
            // Arrange
            Game game = new Game();
            game.Board[1, 3] = Colour.White;
            game.Board[2, 3] = Colour.White;
            // 0 1 2 3 4 5 6 7
            // v
            // 0 0 0 0 2 0 0 0 0 <
            // 1 0 0 0 1 0 0 0 0
            // 2 0 0 0 1 0 0 0 0
            // 3 0 0 0 1 2 0 0 0
            // 4 0 0 0 2 1 0 0 0
            // 5 0 0 0 0 0 0 0 0
            // 6 0 0 0 0 0 0 0 0
            // 7 0 0 0 0 0 0 0 0
            // Act
            game.Turn = Colour.Black;
            var actual = game.DoMove(0, 3);
            // Assert
            Assert.IsTrue(actual);
            Assert.AreEqual(Colour.Black, game.Board[0, 3]);
            Assert.AreEqual(Colour.Black, game.Board[1, 3]);
            Assert.AreEqual(Colour.Black, game.Board[2, 3]);
            Assert.AreEqual(Colour.Black, game.Board[3, 3]);
            Assert.AreEqual(Colour.Black, game.Board[4, 3]);
            Assert.AreEqual(Colour.White, game.Turn);
        }
        [Test]
        public void DoMove_ZetAanDeRandBoven_ReturnFalse() {
            // Arrange
            Game game = new Game();
            game.Board[1, 3] = Colour.White;
            game.Board[2, 3] = Colour.White;
            // 0 1 2 3 4 5 6 7
            // v
            // 0 0 0 0 1 0 0 0 0 <
            // 1 0 0 0 1 0 0 0 0
            // 2 0 0 0 1 0 0 0 0
            // 3 0 0 0 1 2 0 0 0
            // 4 0 0 0 2 1 0 0 0
            // 5 0 0 0 0 0 0 0 0
            // 6 0 0 0 0 0 0 0 0
            // 7 0 0 0 0 0 0 0 0
            // Act
            game.Turn = Colour.White;
            var actual = game.DoMove(0, 3);
            // Assert
            Assert.IsFalse(actual);
            Assert.AreEqual(Colour.White, game.Board[3, 3]);
            Assert.AreEqual(Colour.White, game.Board[4, 4]);
            Assert.AreEqual(Colour.Black, game.Board[3, 4]);
            Assert.AreEqual(Colour.Black, game.Board[4, 3]);
            Assert.AreEqual(Colour.White, game.Board[1, 3]);
            Assert.AreEqual(Colour.White, game.Board[2, 3]);
            Assert.AreEqual(Colour.None, game.Board[0, 3]);
        }
        [Test]
        public void DoMove_ZetAanDeRandBovenEnTotBenedenReedsGevuld_ReturnTrue() {
            // Arrange
            Game game = new Game();
            game.Board[1, 3] = Colour.White;
            game.Board[2, 3] = Colour.White;
            game.Board[3, 3] = Colour.White;
            game.Board[4, 3] = Colour.White;
            game.Board[5, 3] = Colour.White;
            game.Board[6, 3] = Colour.White;
            game.Board[7, 3] = Colour.Black;
            // 0 1 2 3 4 5 6 7
            // v
            // 0 0 0 0 2 0 0 0 0 <
            // 1 0 0 0 1 0 0 0 0
            // 2 0 0 0 1 0 0 0 0
            // 3 0 0 0 1 2 0 0 0
            // 4 0 0 0 1 1 0 0 0
            // 5 0 0 0 1 0 0 0 0
            // 6 0 0 0 1 0 0 0 0
            // 7 0 0 0 2 0 0 0 0
            // Act
            game.Turn = Colour.Black;
            var actual = game.DoMove(0, 3);
            // Assert
            Assert.IsTrue(actual);
            Assert.AreEqual(Colour.Black, game.Board[0, 3]);
            Assert.AreEqual(Colour.Black, game.Board[1, 3]);
            Assert.AreEqual(Colour.Black, game.Board[2, 3]);
            Assert.AreEqual(Colour.Black, game.Board[3, 3]);
            Assert.AreEqual(Colour.Black, game.Board[4, 3]);
            Assert.AreEqual(Colour.Black, game.Board[5, 3]);
            Assert.AreEqual(Colour.Black, game.Board[6, 3]);
            Assert.AreEqual(Colour.Black, game.Board[7, 3]);
        }
        [Test]
        public void DoMove_ZetAanDeRandBovenEnTotBenedenReedsGevuld_ReturnFalse() {
            // Arrange
            Game game = new Game();
            game.Board[1, 3] = Colour.White;
            game.Board[2, 3] = Colour.White;
            game.Board[3, 3] = Colour.White;
            game.Board[4, 3] = Colour.White;
            game.Board[5, 3] = Colour.White;
            game.Board[6, 3] = Colour.White;
            game.Board[7, 3] = Colour.White;
            // 0 1 2 3 4 5 6 7
            // v
            // 0 0 0 0 2 0 0 0 0 <
            // 1 0 0 0 1 0 0 0 0
            // 2 0 0 0 1 0 0 0 0
            // 3 0 0 0 1 2 0 0 0
            // 4 0 0 0 1 1 0 0 0
            // 5 0 0 0 1 0 0 0 0
            // 6 0 0 0 1 0 0 0 0
            // 7 0 0 0 1 0 0 0 0
            // Act
            game.Turn = Colour.Black;
            var actual = game.DoMove(0, 3);
            // Assert
            Assert.IsFalse(actual);
            Assert.AreEqual(Colour.White, game.Board[3, 3]);
            Assert.AreEqual(Colour.White, game.Board[4, 4]);
            Assert.AreEqual(Colour.Black, game.Board[3, 4]);
            Assert.AreEqual(Colour.White, game.Board[4, 3]);
            Assert.AreEqual(Colour.White, game.Board[1, 3]);
            Assert.AreEqual(Colour.White, game.Board[2, 3]);
            Assert.AreEqual(Colour.None, game.Board[0, 3]);
        }
        [Test]
        public void DoMove_ZetAanDeRandRechts_ReturnTrue() {
            // Arrange
            Game game = new Game();
            game.Board[4, 5] = Colour.White;
            game.Board[4, 6] = Colour.White;
            // 0 1 2 3 4 5 6 7
            // v
            // 0 0 0 0 0 0 0 0 0
            // 1 0 0 0 0 0 0 0 0
            // 2 0 0 0 0 0 0 0 0
            // 3 0 0 0 1 2 0 0 0
            // 4 0 0 0 2 1 1 1 2 <
            // 5 0 0 0 0 0 0 0 0
            // 6 0 0 0 0 0 0 0 0
            // 7 0 0 0 0 0 0 0 0
            // Act
            game.Turn = Colour.Black;
            var actual = game.DoMove(4, 7);
            // Assert
            Assert.IsTrue(actual);
            Assert.AreEqual(Colour.Black, game.Board[4, 3]);
            Assert.AreEqual(Colour.Black, game.Board[4, 4]);
            Assert.AreEqual(Colour.Black, game.Board[4, 5]);
            Assert.AreEqual(Colour.Black, game.Board[4, 6]);
            Assert.AreEqual(Colour.Black, game.Board[4, 7]);
        }
        [Test]
        public void DoMove_ZetAanDeRandRechts_ReturnFalse() {
            // Arrange
            Game game = new Game();
            game.Board[4, 5] = Colour.White;
            game.Board[4, 6] = Colour.White;
            // 0 1 2 3 4 5 6 7
            // v
            // 0 0 0 0 1 0 0 0 0
            // 1 0 0 0 1 0 0 0 0
            // 2 0 0 0 1 0 0 0 0
            // 3 0 0 0 1 2 0 0 0
            // 4 0 0 0 2 1 1 1 1 <
            // 5 0 0 0 0 0 0 0 0
            // 6 0 0 0 0 0 0 0 0
            // 7 0 0 0 0 0 0 0 0
            // Act
            game.Turn = Colour.White;
            var actual = game.DoMove(4, 7);
            // Assert
            Assert.IsFalse(actual);
            Assert.AreEqual(Colour.White, game.Board[3, 3]);
            Assert.AreEqual(Colour.White, game.Board[4, 4]);
            Assert.AreEqual(Colour.Black, game.Board[3, 4]);
            Assert.AreEqual(Colour.Black, game.Board[4, 3]);
            Assert.AreEqual(Colour.White, game.Board[4, 5]);
            Assert.AreEqual(Colour.White, game.Board[4, 6]);
            Assert.AreEqual(Colour.None, game.Board[4, 7]);
        }
        [Test]
        public void DoMove_ZetAanDeRandRechtsEnTotLinksReedsGevuld_ReturnTrue() {
            // Arrange
            Game game = new Game();
            game.Board[4, 0] = Colour.Black;
            game.Board[4, 1] = Colour.White;
            game.Board[4, 2] = Colour.White;
            game.Board[4, 3] = Colour.White;
            game.Board[4, 4] = Colour.White;
            game.Board[4, 5] = Colour.White;
            game.Board[4, 6] = Colour.White;
            // 0 1 2 3 4 5 6 7
            // v
            // 0 0 0 0 0 0 0 0 0
            // 1 0 0 0 0 0 0 0 0
            // 2 0 0 0 0 0 0 0 0
            // 3 0 0 0 1 2 0 0 0
            // 4 2 1 1 1 1 1 1 2 <
            // 5 0 0 0 0 0 0 0 0
            // 6 0 0 0 0 0 0 0 0
            // 7 0 0 0 0 0 0 0 0
            // Act
            game.Turn = Colour.Black;
            var actual = game.DoMove(4, 7);
            // Assert
            Assert.IsTrue(actual);
            Assert.AreEqual(Colour.Black, game.Board[4, 0]);
            Assert.AreEqual(Colour.Black, game.Board[4, 1]);
            Assert.AreEqual(Colour.Black, game.Board[4, 2]);
            Assert.AreEqual(Colour.Black, game.Board[4, 3]);
            Assert.AreEqual(Colour.Black, game.Board[4, 4]);
            Assert.AreEqual(Colour.Black, game.Board[4, 5]);
            Assert.AreEqual(Colour.Black, game.Board[4, 6]);
            Assert.AreEqual(Colour.Black, game.Board[4, 7]);
        }
        [Test]
        public void DoMove_ZetAanDeRandRechtsEnTotLinksReedsGevuld_ReturnFalse() {
            // Arrange
            Game game = new Game();
            game.Board[4, 0] = Colour.Black;
            game.Board[4, 1] = Colour.White;
            game.Board[4, 2] = Colour.White;
            game.Board[4, 3] = Colour.White;
            game.Board[4, 4] = Colour.White;
            game.Board[4, 5] = Colour.White;
            game.Board[4, 6] = Colour.White;
            // 0 1 2 3 4 5 6 7
            // v
            // 0 0 0 0 0 0 0 0 0
            // 1 0 0 0 0 0 0 0 0
            // 2 0 0 0 0 0 0 0 0
            // 3 0 0 0 1 2 0 0 0
            // 4 2 1 1 1 1 1 1 1 <
            // 5 0 0 0 0 0 0 0 0
            // 6 0 0 0 0 0 0 0 0
            // 7 0 0 0 0 0 0 0 0
            // Act
            game.Turn = Colour.White;
            var actual = game.DoMove(4, 7);
            // Assert
            Assert.IsFalse(actual);
            Assert.AreEqual(Colour.White, game.Board[3, 3]);
            Assert.AreEqual(Colour.White, game.Board[4, 4]);
            Assert.AreEqual(Colour.Black, game.Board[3, 4]);
            Assert.AreEqual(Colour.White, game.Board[4, 3]);
            Assert.AreEqual(Colour.Black, game.Board[4, 0]);
            Assert.AreEqual(Colour.White, game.Board[4, 1]);
            Assert.AreEqual(Colour.White, game.Board[4, 2]);
            Assert.AreEqual(Colour.White, game.Board[4, 5]);
            Assert.AreEqual(Colour.White, game.Board[4, 6]);
            Assert.AreEqual(Colour.None, game.Board[4, 7]);
        }
        // 0 1 2 3 4 5 6 7
        //
        // 0 0 0 0 0 0 0 0 0
        // 1 0 0 0 0 0 0 0 0
        // 2 0 0 0 0 0 0 0 0
        // 3 0 0 0 1 2 0 0 0
        // 4 0 0 0 2 1 0 0 0
        // 5 0 0 0 0 0 0 0 0
        // 6 0 0 0 0 0 0 0 0
        // 7 0 0 0 0 0 0 0 0
        [Test]
        public void DoMove_StartSituatieZet22White_ReturnFalse() {
            // Arrange
            Game game = new Game();
            // 0 1 2 3 4 5 6 7
            // v
            // 0 0 0 0 0 0 0 0 0
            // 1 0 0 0 0 0 0 0 0
            // 2 0 0 1 0 0 0 0 0 <
            // 3 0 0 0 1 2 0 0 0
            // 4 0 0 0 2 1 0 0 0
            // 5 0 0 0 0 0 0 0 0
            // 6 0 0 0 0 0 0 0 0
            // 7 0 0 0 0 0 0 0 0
            // Act
            game.Turn = Colour.White;
            var actual = game.DoMove(2, 2);
            // Assert
            Assert.IsFalse(actual);
            Assert.AreEqual(Colour.White, game.Board[3, 3]);
            Assert.AreEqual(Colour.White, game.Board[4, 4]);
            Assert.AreEqual(Colour.Black, game.Board[3, 4]);
            Assert.AreEqual(Colour.Black, game.Board[4, 3]);
            Assert.AreEqual(Colour.None, game.Board[2, 2]);
        }
        [Test]
        public void DoMove_StartSituatieZet22Black_ReturnFalse() {
            // Arrange
            Game game = new Game();
            // 0 1 2 3 4 5 6 7
            // v
            // 0 0 0 0 0 0 0 0 0
            // 1 0 0 0 0 0 0 0 0
            // 2 0 0 2 0 0 0 0 0 <
            // 3 0 0 0 1 2 0 0 0
            // 4 0 0 0 2 1 0 0 0
            // 5 0 0 0 0 0 0 0 0
            // 6 0 0 0 0 0 0 0 0
            // 7 0 0 0 0 0 0 0 0
            // Act
            game.Turn = Colour.Black;
            var actual = game.DoMove(2, 2);
            // Assert
            Assert.IsFalse(actual);
            Assert.AreEqual(Colour.White, game.Board[3, 3]);
            Assert.AreEqual(Colour.White, game.Board[4, 4]);
            Assert.AreEqual(Colour.Black, game.Board[3, 4]);
            Assert.AreEqual(Colour.Black, game.Board[4, 3]);
            Assert.AreEqual(Colour.None, game.Board[2, 2]);
        }
        [Test]
        public void DoMove_ZetAanDeRandRechtsBoven_ReturnTrue() {
            // Arrange
            Game game = new Game();
            game.Board[2, 5] = Colour.Black;
            game.Board[1, 6] = Colour.Black;
            game.Board[5, 2] = Colour.White;
            // 0 1 2 3 4 5 6 7
            // v
            // 0 0 0 0 0 0 0 0 1 <
            // 1 0 0 0 0 0 0 2 0
            // 2 0 0 0 0 0 2 0 0
            // 3 0 0 0 1 2 0 0 0
            // 4 0 0 0 2 1 0 0 0
            // 5 0 0 1 0 0 0 0 0
            // 6 0 0 0 0 0 0 0 0
            // 7 0 0 0 0 0 0 0 0
            // Act
            game.Turn = Colour.White;
            var actual = game.DoMove(0, 7);
            // Assert
            Assert.IsTrue(actual);
            Assert.AreEqual(Colour.White, game.Board[5, 2]);
            Assert.AreEqual(Colour.White, game.Board[4, 3]);
            Assert.AreEqual(Colour.White, game.Board[3, 4]);
            Assert.AreEqual(Colour.White, game.Board[2, 5]);
            Assert.AreEqual(Colour.White, game.Board[1, 6]);
            Assert.AreEqual(Colour.White, game.Board[0, 7]);
        }
        [Test]
        public void DoMove_ZetAanDeRandRechtsBoven_ReturnFalse() {
            // Arrange
            Game game = new Game();
            game.Board[2, 5] = Colour.Black;
            game.Board[1, 6] = Colour.Black;
            game.Board[5, 2] = Colour.White;
            // 0 1 2 3 4 5 6 7
            // v
            // 0 0 0 0 0 0 0 0 2 <
            // 1 0 0 0 0 0 0 2 0
            // 2 0 0 0 0 0 2 0 0
            // 3 0 0 0 1 2 0 0 0
            // 4 0 0 0 2 1 0 0 0
            // 5 0 0 1 0 0 0 0 0
            // 6 0 0 0 0 0 0 0 0
            // 7 0 0 0 0 0 0 0 0
            // Act
            game.Turn = Colour.Black;
            var actual = game.DoMove(0, 7);
            // Assert
            Assert.IsFalse(actual);
            Assert.AreEqual(Colour.White, game.Board[3, 3]);
            Assert.AreEqual(Colour.White, game.Board[4, 4]);
            Assert.AreEqual(Colour.Black, game.Board[3, 4]);
            Assert.AreEqual(Colour.Black, game.Board[4, 3]);
            Assert.AreEqual(Colour.Black, game.Board[1, 6]);
            Assert.AreEqual(Colour.Black, game.Board[2, 5]);
            Assert.AreEqual(Colour.White, game.Board[5, 2]);
            Assert.AreEqual(Colour.None, game.Board[0, 7]);
        }
        [Test]
        public void DoMove_ZetAanDeRandRechtsOnder_ReturnTrue() {
            // Arrange
            Game game = new Game();
            game.Board[2, 2] = Colour.Black;
            game.Board[5, 5] = Colour.White;
            game.Board[6, 6] = Colour.White;
            // 0 1 2 3 4 5 6 7
            // v
            // 0 0 0 0 0 0 0 0 0
            // 1 0 0 0 0 0 0 0 0
            // 2 0 0 2 0 0 0 0 0
            // 3 0 0 0 1 2 0 0 0
            // 4 0 0 0 2 1 0 0 0
            // 5 0 0 0 0 0 1 0 0
            // 6 0 0 0 0 0 0 1 0
            // 7 0 0 0 0 0 0 0 2 <
            // Act
            game.Turn = Colour.Black;
            var actual = game.DoMove(7, 7);
            // Assert
            Assert.IsTrue(actual);
            Assert.AreEqual(Colour.Black, game.Board[2, 2]);
            Assert.AreEqual(Colour.Black, game.Board[3, 3]);
            Assert.AreEqual(Colour.Black, game.Board[4, 4]);
            Assert.AreEqual(Colour.Black, game.Board[5, 5]);
            Assert.AreEqual(Colour.Black, game.Board[6, 6]);
            Assert.AreEqual(Colour.Black, game.Board[7, 7]);
        }

        [Test]
        public void DoMove_ZetAanDeRandRechtsOnder_ReturnFalse() {
            // Arrange
            Game game = new Game();
            game.Board[2, 2] = Colour.Black;
            game.Board[5, 5] = Colour.White;
            game.Board[6, 6] = Colour.White;
            // 0 1 2 3 4 5 6 7
            // v
            // 0 0 0 0 0 0 0 0 0
            // 1 0 0 0 0 0 0 0 0
            // 2 0 0 2 0 0 0 0 0
            // 3 0 0 0 1 2 0 0 0
            // 4 0 0 0 2 1 0 0 0
            // 5 0 0 0 0 0 1 0 0
            // 6 0 0 0 0 0 0 1 0
            // 7 0 0 0 0 0 0 0 1 <
            // Act
            game.Turn = Colour.White;
            var actual = game.DoMove(7, 7);
            // Assert
            Assert.IsFalse(actual);
            Assert.AreEqual(Colour.White, game.Board[3, 3]);
            Assert.AreEqual(Colour.White, game.Board[4, 4]);
            Assert.AreEqual(Colour.Black, game.Board[3, 4]);
            Assert.AreEqual(Colour.Black, game.Board[4, 3]);
            Assert.AreEqual(Colour.Black, game.Board[2, 2]);
            Assert.AreEqual(Colour.White, game.Board[5, 5]);
            Assert.AreEqual(Colour.White, game.Board[6, 6]);
            Assert.AreEqual(Colour.None, game.Board[7, 7]);
        }
        [Test]
        public void DoMove_ZetAanDeRandLinksBoven_ReturnTrue() {
            // Arrange
            Game game = new Game();
            game.Board[1, 1] = Colour.White;
            game.Board[2, 2] = Colour.White;
            game.Board[5, 5] = Colour.Black;
            // 0 1 2 3 4 5 6 7
            // v
            // 0 2 0 0 0 0 0 0 0 <
            // 1 0 1 0 0 0 0 0 0
            // 2 0 0 1 0 0 0 0 0
            // 3 0 0 0 1 2 0 0 0
            // 4 0 0 0 2 1 0 0 0
            // 5 0 0 0 0 0 2 0 0
            // 6 0 0 0 0 0 0 0 0
            // 7 0 0 0 0 0 0 0 0
            // Act
            game.Turn = Colour.Black;
            var actual = game.DoMove(0, 0);
            // Assert
            Assert.IsTrue(actual);
            Assert.AreEqual(Colour.Black, game.Board[0, 0]);
            Assert.AreEqual(Colour.Black, game.Board[1, 1]);
            Assert.AreEqual(Colour.Black, game.Board[2, 2]);
            Assert.AreEqual(Colour.Black, game.Board[3, 3]);
            Assert.AreEqual(Colour.Black, game.Board[4, 4]);
            Assert.AreEqual(Colour.Black, game.Board[5, 5]);
        }
        [Test]
        public void DoMove_ZetAanDeRandLinksBoven_ReturnFalse() {
            // Arrange
            Game game = new Game();
            game.Board[1, 1] = Colour.White;
            game.Board[2, 2] = Colour.White;
            game.Board[5, 5] = Colour.Black;
            // 0 1 2 3 4 5 6 7
            // v
            // 0 1 0 0 0 0 0 0 0 <
            // 1 0 1 0 0 0 0 0 0
            // 2 0 0 1 0 0 0 0 0
            // 3 0 0 0 1 2 0 0 0
            // 4 0 0 0 2 1 0 0 0
            // 5 0 0 0 0 0 2 0 0
            // 6 0 0 0 0 0 0 0 0
            // 7 0 0 0 0 0 0 0 0
            // Act
            game.Turn = Colour.White;
            var actual = game.DoMove(0, 0);
            // Assert
            Assert.IsFalse(actual);
            Assert.AreEqual(Colour.White, game.Board[3, 3]);
            Assert.AreEqual(Colour.White, game.Board[4, 4]);
            Assert.AreEqual(Colour.Black, game.Board[3, 4]);
            Assert.AreEqual(Colour.Black, game.Board[4, 3]);
            Assert.AreEqual(Colour.White, game.Board[1, 1]);
            Assert.AreEqual(Colour.White, game.Board[2, 2]);
            Assert.AreEqual(Colour.Black, game.Board[5, 5]);
            Assert.AreEqual(Colour.None, game.Board[0, 0]);
        }
        [Test]
        public void DoMove_ZetAanDeRandLinksOnder_ReturnTrue() {
            // Arrange
            Game game = new Game();
            game.Board[2, 5] = Colour.White;
            game.Board[5, 2] = Colour.Black;
            game.Board[6, 1] = Colour.Black;
            // 0 1 2 3 4 5 6 7
            // v
            // 0 0 0 0 0 0 0 0 0
            // 1 0 0 0 0 0 0 0 0
            // 2 0 0 0 0 0 1 0 0
            // 3 0 0 0 1 2 0 0 0
            // 4 0 0 0 2 1 0 0 0
            // 5 0 0 2 0 0 0 0 0
            // 6 0 2 0 0 0 0 0 0
            // 7 1 0 0 0 0 0 0 0 <
            // Act
            game.Turn = Colour.White;
            var actual = game.DoMove(7, 0);
            // Assert
            Assert.IsTrue(actual);
            Assert.AreEqual(Colour.White, game.Board[7, 0]);
            Assert.AreEqual(Colour.White, game.Board[6, 1]);
            Assert.AreEqual(Colour.White, game.Board[5, 2]);
            Assert.AreEqual(Colour.White, game.Board[4, 3]);
            Assert.AreEqual(Colour.White, game.Board[3, 4]);
            Assert.AreEqual(Colour.White, game.Board[2, 5]);
        }
        [Test]
        public void DoMove_ZetAanDeRandLinksOnder_ReturnFalse() {
            // Arrange
            Game game = new Game();
            game.Board[2, 5] = Colour.White;
            game.Board[5, 2] = Colour.Black;
            game.Board[6, 1] = Colour.Black;
            // 0 1 2 3 4 5 6 7
            // v
            // 0 0 0 0 0 0 0 0 0
            // 1 0 0 0 0 0 0 0 0
            // 2 0 0 0 0 0 1 0 0
            // 3 0 0 0 1 2 0 0 0
            // 4 0 0 0 2 1 0 0 0
            // 5 0 0 2 0 0 0 0 0
            // 6 0 2 0 0 0 0 0 0
            // 7 2 0 0 0 0 0 0 0 <
            // Act
            game.Turn = Colour.Black;
            var actual = game.DoMove(7, 0);
            // Assert
            Assert.IsFalse(actual);
            Assert.AreEqual(Colour.White, game.Board[3, 3]);
            Assert.AreEqual(Colour.White, game.Board[4, 4]);
            Assert.AreEqual(Colour.Black, game.Board[3, 4]);
            Assert.AreEqual(Colour.Black, game.Board[4, 3]);
            Assert.AreEqual(Colour.White, game.Board[2, 5]);
            Assert.AreEqual(Colour.Black, game.Board[5, 2]);
            Assert.AreEqual(Colour.Black, game.Board[6, 1]);
            Assert.AreEqual(Colour.None, game.Board[7, 7]);
            Assert.AreEqual(Colour.None, game.Board[7, 0]);
        }
        [Test]
        public void Pass_BlackAanZetNonePossibleMove_ReturnTrueEnWisselBeurt() {
            // Arrange (zowel wit als zwart kunnen niet meer)
            Game game = new Game();
            game.Board[0, 0] = Colour.White;
            game.Board[0, 1] = Colour.White;
            game.Board[0, 2] = Colour.White;
            game.Board[0, 3] = Colour.White;
            game.Board[0, 4] = Colour.White;
            game.Board[0, 5] = Colour.White;
            game.Board[0, 6] = Colour.White;
            game.Board[0, 7] = Colour.White;
            game.Board[1, 0] = Colour.White;
            game.Board[1, 1] = Colour.White;
            game.Board[1, 2] = Colour.White;
            game.Board[1, 3] = Colour.White;
            game.Board[1, 4] = Colour.White;
            game.Board[1, 5] = Colour.White;
            game.Board[1, 6] = Colour.White;
            game.Board[1, 7] = Colour.White;
            game.Board[2, 0] = Colour.White;
            game.Board[2, 1] = Colour.White;
            game.Board[2, 2] = Colour.White;
            game.Board[2, 3] = Colour.White;
            game.Board[2, 4] = Colour.White;
            game.Board[2, 5] = Colour.White;
            game.Board[2, 6] = Colour.White;
            game.Board[2, 7] = Colour.White;
            game.Board[3, 0] = Colour.White;
            game.Board[3, 1] = Colour.White;
            game.Board[3, 2] = Colour.White;
            game.Board[3, 3] = Colour.White;
            game.Board[3, 4] = Colour.White;
            game.Board[3, 5] = Colour.White;
            game.Board[3, 6] = Colour.White;
            game.Board[3, 7] = Colour.None;
            game.Board[4, 0] = Colour.White;
            game.Board[4, 1] = Colour.White;
            game.Board[4, 2] = Colour.White;
            game.Board[4, 3] = Colour.White;
            game.Board[4, 4] = Colour.White;
            game.Board[4, 5] = Colour.White;
            game.Board[4, 6] = Colour.None;
            game.Board[4, 7] = Colour.None;
            game.Board[5, 0] = Colour.White;
            game.Board[5, 1] = Colour.White;
            game.Board[5, 2] = Colour.White;
            game.Board[5, 3] = Colour.White;
            game.Board[5, 4] = Colour.White;
            game.Board[5, 5] = Colour.White;
            game.Board[5, 6] = Colour.None;
            game.Board[5, 7] = Colour.Black;
            game.Board[6, 0] = Colour.White;
            game.Board[6, 1] = Colour.White;
            game.Board[6, 2] = Colour.White;
            game.Board[6, 3] = Colour.White;
            game.Board[6, 4] = Colour.White;
            game.Board[6, 5] = Colour.White;
            game.Board[6, 6] = Colour.White;
            game.Board[6, 7] = Colour.None;
            game.Board[7, 0] = Colour.White;
            game.Board[7, 1] = Colour.White;
            game.Board[7, 2] = Colour.White;
            game.Board[7, 3] = Colour.White;
            game.Board[7, 4] = Colour.White;
            game.Board[7, 5] = Colour.White;
            game.Board[7, 6] = Colour.White;
            game.Board[7, 7] = Colour.White;
            // 0 1 2 3 4 5 6 7
            // v
            // 0 1 1 1 1 1 1 1 1
            // 1 1 1 1 1 1 1 1 1
            // 2 1 1 1 1 1 1 1 1
            // 3 1 1 1 1 1 1 1 0
            // 4 1 1 1 1 1 1 0 0
            // 5 1 1 1 1 1 1 0 2
            // 6 1 1 1 1 1 1 1 0
            // 7 1 1 1 1 1 1 1 1
            // Act
            game.Turn = Colour.Black;
            var actual = game.Pass();
            // Assert
            Assert.IsTrue(actual);
            Assert.AreEqual(Colour.White, game.Turn);
        }
        [Test]
        public void Pass_WhiteAanZetNonePossibleMove_ReturnTrueEnWisselBeurt() {
            // Arrange (zowel wit als zwart kunnen niet meer)
            Game game = new Game();
            game.Board[0, 0] = Colour.White;
            game.Board[0, 1] = Colour.White;
            game.Board[0, 2] = Colour.White;
            game.Board[0, 3] = Colour.White;
            game.Board[0, 4] = Colour.White;
            game.Board[0, 5] = Colour.White;
            game.Board[0, 6] = Colour.White;
            game.Board[0, 7] = Colour.White;
            game.Board[1, 0] = Colour.White;
            game.Board[1, 1] = Colour.White;
            game.Board[1, 2] = Colour.White;
            game.Board[1, 3] = Colour.White;
            game.Board[1, 4] = Colour.White;
            game.Board[1, 5] = Colour.White;
            game.Board[1, 6] = Colour.White;
            game.Board[1, 7] = Colour.White;
            game.Board[2, 0] = Colour.White;
            game.Board[2, 1] = Colour.White;
            game.Board[2, 2] = Colour.White;
            game.Board[2, 3] = Colour.White;
            game.Board[2, 4] = Colour.White;
            game.Board[2, 5] = Colour.White;
            game.Board[2, 6] = Colour.White;
            game.Board[2, 7] = Colour.White;
            game.Board[3, 0] = Colour.White;
            game.Board[3, 1] = Colour.White;
            game.Board[3, 2] = Colour.White;
            game.Board[3, 3] = Colour.White;
            game.Board[3, 4] = Colour.White;
            game.Board[3, 5] = Colour.White;
            game.Board[3, 6] = Colour.White;
            game.Board[3, 7] = Colour.None;
            game.Board[4, 0] = Colour.White;
            game.Board[4, 1] = Colour.White;
            game.Board[4, 2] = Colour.White;
            game.Board[4, 3] = Colour.White;
            game.Board[4, 4] = Colour.White;
            game.Board[4, 5] = Colour.White;
            game.Board[4, 6] = Colour.None;
            game.Board[4, 7] = Colour.None;
            game.Board[5, 0] = Colour.White;
            game.Board[5, 1] = Colour.White;
            game.Board[5, 2] = Colour.White;
            game.Board[5, 3] = Colour.White;
            game.Board[5, 4] = Colour.White;
            game.Board[5, 5] = Colour.White;
            game.Board[5, 6] = Colour.None;
            game.Board[5, 7] = Colour.Black;
            game.Board[6, 0] = Colour.White;
            game.Board[6, 1] = Colour.White;
            game.Board[6, 2] = Colour.White;
            game.Board[6, 3] = Colour.White;
            game.Board[6, 4] = Colour.White;
            game.Board[6, 5] = Colour.White;
            game.Board[6, 6] = Colour.White;
            game.Board[6, 7] = Colour.None;
            game.Board[7, 0] = Colour.White;
            game.Board[7, 1] = Colour.White;
            game.Board[7, 2] = Colour.White;
            game.Board[7, 3] = Colour.White;
            game.Board[7, 4] = Colour.White;
            game.Board[7, 5] = Colour.White;
            game.Board[7, 6] = Colour.White;
            game.Board[7, 7] = Colour.White;
            // 0 1 2 3 4 5 6 7
            // v
            // 0 1 1 1 1 1 1 1 1
            // 1 1 1 1 1 1 1 1 1
            // 2 1 1 1 1 1 1 1 1
            // 3 1 1 1 1 1 1 1 0
            // 4 1 1 1 1 1 1 0 0
            // 5 1 1 1 1 1 1 0 2
            // 6 1 1 1 1 1 1 1 0
            // 7 1 1 1 1 1 1 1 1
            // Act
            game.Turn = Colour.White;
            var actual = game.Pass();
            // Assert
            Assert.IsTrue(actual);
            Assert.AreEqual(Colour.Black, game.Turn);
        }
        [Test]
        public void GameOver_NonePossibleMove_ReturnTrue() {
            // Arrange (zowel wit als zwart kunnen niet meer)
            Game game = new Game();
            game.Board[0, 0] = Colour.White;
            game.Board[0, 1] = Colour.White;
            game.Board[0, 2] = Colour.White;
            game.Board[0, 3] = Colour.White;
            game.Board[0, 4] = Colour.White;
            game.Board[0, 5] = Colour.White;
            game.Board[0, 6] = Colour.White;
            game.Board[0, 7] = Colour.White;
            game.Board[1, 0] = Colour.White;
            game.Board[1, 1] = Colour.White;
            game.Board[1, 2] = Colour.White;
            game.Board[1, 3] = Colour.White;
            game.Board[1, 4] = Colour.White;
            game.Board[1, 5] = Colour.White;
            game.Board[1, 6] = Colour.White;
            game.Board[1, 7] = Colour.White;
            game.Board[2, 0] = Colour.White;
            game.Board[2, 1] = Colour.White;
            game.Board[2, 2] = Colour.White;
            game.Board[2, 3] = Colour.White;
            game.Board[2, 4] = Colour.White;
            game.Board[2, 5] = Colour.White;
            game.Board[2, 6] = Colour.White;
            game.Board[2, 7] = Colour.White;
            game.Board[3, 0] = Colour.White;
            game.Board[3, 1] = Colour.White;
            game.Board[3, 2] = Colour.White;
            game.Board[3, 3] = Colour.White;
            game.Board[3, 4] = Colour.White;
            game.Board[3, 5] = Colour.White;
            game.Board[3, 6] = Colour.White;
            game.Board[3, 7] = Colour.None;
            game.Board[4, 0] = Colour.White;
            game.Board[4, 1] = Colour.White;
            game.Board[4, 2] = Colour.White;
            game.Board[4, 3] = Colour.White;
            game.Board[4, 4] = Colour.White;
            game.Board[4, 5] = Colour.White;
            game.Board[4, 6] = Colour.None;
            game.Board[4, 7] = Colour.None;
            game.Board[5, 0] = Colour.White;
            game.Board[5, 1] = Colour.White;
            game.Board[5, 2] = Colour.White;
            game.Board[5, 3] = Colour.White;
            game.Board[5, 4] = Colour.White;
            game.Board[5, 5] = Colour.White;
            game.Board[5, 6] = Colour.None;
            game.Board[5, 7] = Colour.Black;
            game.Board[6, 0] = Colour.White;
            game.Board[6, 1] = Colour.White;
            game.Board[6, 2] = Colour.White;
            game.Board[6, 3] = Colour.White;
            game.Board[6, 4] = Colour.White;
            game.Board[6, 5] = Colour.White;
            game.Board[6, 6] = Colour.White;
            game.Board[6, 7] = Colour.None;
            game.Board[7, 0] = Colour.White;
            game.Board[7, 1] = Colour.White;
            game.Board[7, 2] = Colour.White;
            game.Board[7, 3] = Colour.White;
            game.Board[7, 4] = Colour.White;
            game.Board[7, 5] = Colour.White;
            game.Board[7, 6] = Colour.White;
            game.Board[7, 7] = Colour.White;
            // 0 1 2 3 4 5 6 7
            // v
            // 0 1 1 1 1 1 1 1 1
            // 1 1 1 1 1 1 1 1 1
            // 2 1 1 1 1 1 1 1 1
            // 3 1 1 1 1 1 1 1 0
            // 4 1 1 1 1 1 1 0 0
            // 5 1 1 1 1 1 1 0 2
            // 6 1 1 1 1 1 1 1 0
            // 7 1 1 1 1 1 1 1 1
            // Act
            game.Turn = Colour.White;
            var actual = game.GameOver();
            // Assert
            Assert.IsTrue(actual);
        }
        [Test]
        public void GameOver_NonePossibleMoveAllesBezet_ReturnTrue() {
            // Arrange (zowel wit als zwart kunnen niet meer)
            Game game = new Game();
            game.Board[0, 0] = Colour.White;
            game.Board[0, 1] = Colour.White;
            game.Board[0, 2] = Colour.White;
            game.Board[0, 3] = Colour.White;
            game.Board[0, 4] = Colour.White;
            game.Board[0, 5] = Colour.White;
            game.Board[0, 6] = Colour.White;
            game.Board[0, 7] = Colour.White;
            game.Board[1, 0] = Colour.White;
            game.Board[1, 1] = Colour.White;
            game.Board[1, 2] = Colour.White;
            game.Board[1, 3] = Colour.White;
            game.Board[1, 4] = Colour.White;
            game.Board[1, 5] = Colour.White;
            game.Board[1, 6] = Colour.White;
            game.Board[1, 7] = Colour.White;
            game.Board[2, 0] = Colour.White;
            game.Board[2, 1] = Colour.White;
            game.Board[2, 2] = Colour.White;
            game.Board[2, 3] = Colour.White;
            game.Board[2, 4] = Colour.White;
            game.Board[2, 5] = Colour.White;
            game.Board[2, 6] = Colour.White;
            game.Board[2, 7] = Colour.White;
            game.Board[3, 0] = Colour.White;
            game.Board[3, 1] = Colour.White;
            game.Board[3, 2] = Colour.White;
            game.Board[3, 3] = Colour.White;
            game.Board[3, 4] = Colour.White;
            game.Board[3, 5] = Colour.White;
            game.Board[3, 6] = Colour.White;
            game.Board[3, 7] = Colour.White;
            game.Board[4, 0] = Colour.White;
            game.Board[4, 1] = Colour.White;
            game.Board[4, 2] = Colour.White;
            game.Board[4, 3] = Colour.White;
            game.Board[4, 4] = Colour.White;
            game.Board[4, 5] = Colour.White;
            game.Board[4, 6] = Colour.Black;
            game.Board[4, 7] = Colour.Black;
            game.Board[5, 0] = Colour.White;
            game.Board[5, 1] = Colour.White;
            game.Board[5, 2] = Colour.White;
            game.Board[5, 3] = Colour.White;
            game.Board[5, 4] = Colour.White;
            game.Board[5, 5] = Colour.White;
            game.Board[5, 6] = Colour.Black;
            game.Board[5, 7] = Colour.Black;
            game.Board[6, 0] = Colour.White;
            game.Board[6, 1] = Colour.White;
            game.Board[6, 2] = Colour.White;
            game.Board[6, 3] = Colour.White;
            game.Board[6, 4] = Colour.White;
            game.Board[6, 5] = Colour.White;
            game.Board[6, 6] = Colour.White;
            game.Board[6, 7] = Colour.Black;
            game.Board[7, 0] = Colour.White;
            game.Board[7, 1] = Colour.White;
            game.Board[7, 2] = Colour.White;
            game.Board[7, 3] = Colour.White;
            game.Board[7, 4] = Colour.White;
            game.Board[7, 5] = Colour.White;
            game.Board[7, 6] = Colour.White;
            game.Board[7, 7] = Colour.White;
            // 0 1 2 3 4 5 6 7
            //
            // 0 1 1 1 1 1 1 1 1
            // 1 1 1 1 1 1 1 1 1
            // 2 1 1 1 1 1 1 1 1
            // 3 1 1 1 1 1 1 1 2
            // 4 1 1 1 1 1 1 2 2
            // 5 1 1 1 1 1 1 2 2
            // 6 1 1 1 1 1 1 1 2
            // 7 1 1 1 1 1 1 1 1
            // Act
            game.Turn = Colour.White;
            var actual = game.GameOver();
            // Assert
            Assert.IsTrue(actual);
        }
        [Test]
        public void GameOver_WelPossibleMove_ReturnFalse() {
            // Arrange
            Game game = new Game();
            // 0 1 2 3 4 5 6 7
            //
            // 0 0 0 0 0 0 0 0 0
            // 1 0 0 0 0 0 0 0 0
            // 2 0 0 0 0 0 0 0 0
            // 3 0 0 0 1 2 0 0 0
            // 4 0 0 0 2 1 0 0 0
            // 5 0 0 0 0 0 0 0 0
            // 6 0 0 0 0 0 0 0 0
            // 7 0 0 0 0 0 0 0 0
            //
            // Act
            game.Turn = Colour.White;
            var actual = game.GameOver();
            // Assert
            Assert.IsFalse(actual);
        }
        [Test]
        public void DominantColour_Gelijk_ReturnColourNone() {
            // Arrange
            Game game = new Game();
            // 0 1 2 3 4 5 6 7
            //
            // 0 0 0 0 0 0 0 0 0
            // 1 0 0 0 0 0 0 0 0
            // 2 0 0 0 0 0 0 0 0
            // 3 0 0 0 1 2 0 0 0
            // 4 0 0 0 2 1 0 0 0
            // 5 0 0 0 0 0 0 0 0
            // 6 0 0 0 0 0 0 0 0
            // 7 0 0 0 0 0 0 0 0
            //
            // Act
            var actual = game.DominantColour();
            // Assert
            Assert.AreEqual(Colour.None, actual);
        }
        [Test]
        public void DominantColour_Black_ReturnColourBlack() {
            // Arrange
            Game game = new Game();
            game.Board[2, 3] = Colour.Black;
            game.Board[3, 3] = Colour.Black;
            game.Board[4, 3] = Colour.Black;
            game.Board[3, 4] = Colour.Black;
            game.Board[4, 4] = Colour.White;
            // 0 1 2 3 4 5 6 7
            //
            // 0 0 0 0 0 0 0 0 0
            // 1 0 0 0 0 0 0 0 0
            // 2 0 0 0 2 0 0 0 0
            // 3 0 0 0 2 2 0 0 0
            // 4 0 0 0 2 1 0 0 0
            // 5 0 0 0 0 0 0 0 0
            // 6 0 0 0 0 0 0 0 0
            // 7 0 0 0 0 0 0 0 0
            //
            // Act
            var actual = game.DominantColour();
            // Assert
            Assert.AreEqual(Colour.Black, actual);
        }
        [Test]
        public void DominantColour_White_ReturnColourWhite() {
            // Arrange
            Game game = new Game();
            game.Board[2, 3] = Colour.White;
            game.Board[3, 3] = Colour.White;
            game.Board[4, 3] = Colour.White;
            game.Board[3, 4] = Colour.White;
            game.Board[4, 4] = Colour.Black;
            // 0 1 2 3 4 5 6 7
            //
            // 0 0 0 0 0 0 0 0 0
            // 1 0 0 0 0 0 0 0 0
            // 2 0 0 0 1 0 0 0 0
            // 3 0 0 0 1 1 0 0 0
            // 4 0 0 0 1 2 0 0 0
            // 5 0 0 0 0 0 0 0 0
            // 6 0 0 0 0 0 0 0 0
            // 7 0 0 0 0 0 0 0 0
            //
            // Act
            var actual = game.DominantColour();
            // Assert
            Assert.AreEqual(Colour.White, actual);
        }
    }
}